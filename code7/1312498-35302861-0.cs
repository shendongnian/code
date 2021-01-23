    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<DateTime> byMinute = new List<DateTime>()
                {
                    new DateTime(2010, 10, 1, 8, 15, 0),
                    new DateTime(2010, 10, 1, 8, 30, 1),
                    new DateTime(2010, 10, 1, 8, 45, 2),
                    new DateTime(2010, 10, 1, 9, 15, 3),
                    new DateTime(2010, 10, 1, 9, 30, 4),
                    new DateTime(2010, 10, 1, 9, 45, 5),
                    new DateTime(2010, 10, 1, 10, 15, 6),
                    new DateTime(2010, 10, 1, 10, 30, 7),
                    new DateTime(2010, 10, 1, 10, 45, 8),
                    new DateTime(2010, 10, 1, 11, 15, 9),
                    new DateTime(2010, 10, 1, 11, 30, 10),
                    new DateTime(2010, 10, 1, 11, 45, 11),
                    new DateTime(2010, 10, 1, 12, 15, 12),
                    new DateTime(2010, 10, 1, 12, 30, 13),
                    new DateTime(2010, 10, 1, 12, 45, 14),
                    new DateTime(2010, 10, 1, 13, 15, 15),
                    new DateTime(2010, 10, 1, 13, 30, 16),
                    new DateTime(2010, 10, 1, 13, 45, 17),
                    new DateTime(2010, 10, 1, 14, 15, 18),
                    new DateTime(2010, 10, 1, 14, 30, 19),
                    new DateTime(2010, 10, 1, 14, 45, 20) 
                }; 
    
                List<DateTime> byHour = new List<DateTime>()
                {
                    new DateTime(2010, 10, 1, 8, 0, 0),
                    new DateTime(2010, 10, 1, 9, 0, 1),
                    new DateTime(2010, 10, 1, 10, 0, 2),
                    new DateTime(2010, 10, 1, 11, 0, 3),
                    new DateTime(2010, 10, 1, 12, 0, 4),
                    new DateTime(2010, 10, 1, 13, 0, 5),
                    new DateTime(2010, 10, 1, 14, 0, 6)
                };
    
                var index = byMinute
                    .Select(m => new Tuple<int,int>(
                        byMinute.IndexOf(m), 
                        byHour.IndexOf(byHour.FirstOrDefault(h => h.Year == m.Year &&
                            h.Month ==  m.Month &&
                            h.Day == m.Day &&
                            h.Hour == m.Hour))));
    
                foreach(var indexItem in index)
                {
                    Console.WriteLine("{0}, {1}", indexItem.Item1, indexItem.Item2);
                }
    
                Console.ReadKey();
            }
        }
    }
