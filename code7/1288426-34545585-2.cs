    public class Program
    {
        public static void Main(string[] args)
        {
            using (var ctx = new MyClass())
            {
                if (!ctx.Products.Any())
                {
                    var product = new Product
                    {
                        ProdPrices = new List<ProdPrice>
                        {
                            new ProdPrice {PermanentlyDelete = true, DateCreated = new DateTime(2015,12,29,18,28,27)},
                            new ProdPrice {PermanentlyDelete = true, DateCreated = new DateTime(2015,12,29,18,28,28)},
                            new ProdPrice {PermanentlyDelete = true, DateCreated = new DateTime(2015,12,29,18,28,28)},
                            new ProdPrice {PermanentlyDelete = true, DateCreated = new DateTime(2015,12,29,18,28,29)},
                            new ProdPrice {PermanentlyDelete = true, DateCreated = new DateTime(2015,12,29,18,28,29)},
                            new ProdPrice {PermanentlyDelete = true, DateCreated = new DateTime(2015,12,30,19,08,38)},
                            new ProdPrice {PermanentlyDelete = false, DateCreated = new DateTime(2015,12,31,10,18,06)},
                            new ProdPrice {PermanentlyDelete = false, DateCreated = new DateTime(2015,12,31,10,18,06)},
                            new ProdPrice {PermanentlyDelete = false, DateCreated = new DateTime(2015,12,31,10,18,07)},
                            new ProdPrice {PermanentlyDelete = false, DateCreated = new DateTime(2015,12,31,10,18,07)},
                            new ProdPrice {PermanentlyDelete = false, DateCreated = new DateTime(2015,12,31,10,18,08)},
                            new ProdPrice {PermanentlyDelete = false, DateCreated = new DateTime(2015,12,31,10,18,08)},
                        }
                    };
                    ctx.Products.Add(product);
                    ctx.SaveChanges();
                    Console.WriteLine("Saved");
                }
            }
            using (var ctx = new MyClass())
            {
                var product = ctx.Products.Find(1);
                var count = product.ProdPrices.Count;
                Console.WriteLine(count);
            }
        }
    }
    public class MyClass : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProdPrice> ProdPrices { get; set; }
    }
    public class Product
    {
        [Key]
        public long ProdID { get; set; }
        public virtual ICollection<ProdPrice> ProdPrices { get; set; }
    }
    public class ProdPrice
    {
        public long ProdPriceID { get; set; }
        public bool PermanentlyDelete { get; set; }
        public DateTime DateCreated { get; set; }
    }
