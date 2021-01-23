    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp1
    {
        class RakeSnapshot
        {
            public string StatusCode;
            public string RakeCode;
        }
        class ProductMovement
        {
            public string Status;
            public string ProductCode;
        }
        sealed class Program
        {
            void run()
            {
                var rakeSnapshots = new List<RakeSnapshot>
                {
                    new RakeSnapshot {StatusCode = "Dumping", RakeCode = "1"},
                    new RakeSnapshot {StatusCode = "Dumping", RakeCode = "1"},
                    new RakeSnapshot {StatusCode = "Dumping", RakeCode = "2"}
                };
                var productMovements = new List<ProductMovement>
                {
                    new ProductMovement {Status = "InProgress", ProductCode = "1"},
                    new ProductMovement {Status = "InProgress", ProductCode = "2"},
                    new ProductMovement {Status = "InProgress", ProductCode = "2"}
                };
                var dumpingRakeSnapshots       = rakeSnapshots.Where(r => r.StatusCode == "Dumping");
                var inProgressProductMovements = productMovements.Where(p => p.Status == "InProgress");
                // Inner join.
                var matches1 =
                    from r in dumpingRakeSnapshots
                    join p in inProgressProductMovements on r.RakeCode equals p.ProductCode
                    select r;
                Console.WriteLine(matches1.Count());
                // Grouped join.
                var matches2 =
                    from r in dumpingRakeSnapshots
                    join p in inProgressProductMovements on r.RakeCode equals p.ProductCode into gj
                    select gj;
                Console.WriteLine(matches2.Count());
                // OP's code.
                var resultCount = 
                    productMovements
                    .Count(x => rakeSnapshots
                    .Where(r => r.StatusCode == "Dumping")
                    .Any(y => y.RakeCode == x.ProductCode && x.Status == "InProgress"));
                Console.WriteLine(resultCount);
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
