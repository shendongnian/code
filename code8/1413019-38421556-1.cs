    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string myColor = "Red";
                var resutls = (from office in Office.offices
                               join worker in Worker.workers on office.ID equals worker.ID
                               select (new { office = office, worker = worker }))
                                .Where(x => x.office.Color == myColor)
                                .Select(x => new {
                                    ID = x.worker.ID,
                                    OfficeID = x.worker.OfficeID, 
                                    FullName = x.worker.FullName, 
                                    OfficeColor = x.office.Color  
                                }).ToList();
              
            }
        }
        public class Office
        {
            public static List<Office> offices { get; set; }
            public int ID { get; set; }
            public string Color { get; set; }
            public Office()
            {
                office = new Office();
            }
        }
        public class Worker
        {
            public static List<Worker> workers { get; set; }
            public int ID { get; set; }
            public int OfficeID { get; set; }
            public string FullName { get; set; }
            //[NotMapped]
            public string OfficeColor { get; set; }
            public Worker()
            {
                workers = new List<Worker>();
            }
        }
    }
