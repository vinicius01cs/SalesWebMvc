using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //Banco de dados populado, corta execução do metodo
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Marley", "bob@gmail.com", new DateTime(1992, 4, 21), 2100.00, d1);
            Seller s2 = new Seller(2, "Joseph Serafin", "joseph@gmail.com", new DateTime(2000, 1, 17), 1300.00, d2);
            Seller s3 = new Seller(3, "David Beckham", "david@gmail.com", new DateTime(2000, 11, 13), 3300.00, d3);
            Seller s4 = new Seller(4, "Amanda Querem", "amanda@gmail.com", new DateTime(1999, 5, 10), 3100.00, d3);
            Seller s5 = new Seller(5, "Julia Querem", "julia@gmail.com", new DateTime(1998, 3, 7), 3800.00, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2022, 9, 11), 5000.01, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2022, 8, 12), 790.01, SaleStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2022, 8, 21), 2500.01, SaleStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2022, 8, 24), 2000.01, SaleStatus.Billed, s1);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2022, 8, 28), 210.01, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5);

            _context.SaveChanges();
        }
    }
}
