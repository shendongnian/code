    class Program
    {
        public class ReleasePlan
        {
            public int ProductProductId { get; set; }
            public int Amount { get; set; }
            public DateTime DateTime { get; set; }
        }
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int DepartmentDepartmentId { get; set; }
        }
        static void Main()
        {
            var products = new List<Product>
            {
                new Product {ProductId = 1, ProductName = "1", DepartmentDepartmentId = 1},
                new Product {ProductId = 2, ProductName = "2", DepartmentDepartmentId = 1},
                new Product {ProductId = 3, ProductName = "3", DepartmentDepartmentId = 1},
            };
            var releasePlans = new List<ReleasePlan>
            {
                new ReleasePlan {ProductProductId = 1, Amount = 1, DateTime = DateTime.Now},
                new ReleasePlan {ProductProductId = 1, Amount = 1, DateTime = DateTime.Now},
                new ReleasePlan {ProductProductId = 1, Amount = 1, DateTime = DateTime.Now.AddMonths(-5)},
                new ReleasePlan {ProductProductId = 2, Amount = 2, DateTime = DateTime.Now},
                new ReleasePlan {ProductProductId = 2, Amount = 2, DateTime = DateTime.Now},
                new ReleasePlan {ProductProductId = 2, Amount = 2, DateTime = DateTime.Now.AddMonths(-5)},
                new ReleasePlan {ProductProductId = 3, Amount = 3, DateTime = DateTime.Now},
                new ReleasePlan {ProductProductId = 3, Amount = 3, DateTime = DateTime.Now},
                new ReleasePlan {ProductProductId = 3, Amount = 3, DateTime = DateTime.Now.AddMonths(-5)},
            };
            var amountByProducts = from rp in releasePlans
                join p in products
                    on rp.ProductProductId equals p.ProductId
                where p.DepartmentDepartmentId == 1 && (rp.DateTime.AddDays(2).Month/3) == 1
                group new {rp, p} by new {rp.ProductProductId, p.ProductId, p.ProductName}
                into grp
                select new
                {
                    grp.Key.ProductId,
                    grp.Key.ProductName,
                    PlannedAmount = grp.Sum(g => g.rp.Amount)
                };
            Console.WriteLine("ProductId    ProductName     PlannedAmount");
            foreach (var producAmount in amountByProducts)
            {
                Console.WriteLine("{0} \t\t{1} \t\t{2}", producAmount.ProductId, producAmount.ProductName,
                    producAmount.PlannedAmount);
            }
        }
    }
