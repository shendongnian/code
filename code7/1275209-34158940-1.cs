    public class Product
    {
        public Product(long id, string name, int major, int minor)
        {
            this.Id = id;
            this.Name = name;
            this.Major = major;
            this.Minor = minor;
        }
        public long Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public string Name { get; set; }
    }
    private static void Main()
    {
        IEnumerable<Product> products = new List<Product>
                                        {
                                            new Product(1, "ssim", 2, 1),
                                            new Product(2, "SSim", 3, 1),
                                            new Product(3, "Counter", 5, 1),
                                            new Product(4, "Counter", 6, 2),
                                            new Product(5, "Counter", 6, 5)
                                        };
        IEnumerable<Product> distinctProducts =
            (from x in products group x by x.Name.ToLower() into g select g.OrderByDescending(y => y.Major).ThenByDescending(y => y.Minor).First()).OrderBy(x => x.Name).ToList();
    }
