    public class productMerchant
        {
            public int productID { get; set; }
            public string productName { get; set; }
            public int qty { get; set; }
            public int price { get; set; }
            public int have { get; set; }
    
            public productMerchant(int productid, string productname, int qtyx, int pricex, int havex)
            {
                this.productID = productid;
                this.productName = productname;
                this.qty = qtyx;
                this.price = pricex;
                this.have = havex;
            }
        }
    
        public static void Main(string[] args)
        {
            List<productMerchant> productMerchants = new List<productMerchant>();
            productMerchants.Add(new productMerchant(10, "A", 1, 0, 0));
            productMerchants.Add(new productMerchant(10, "A", 2, 0, 0));
            productMerchants.Add(new productMerchant(10, "A", 3, 0, 0));
    
            productMerchants.Add(new productMerchant(11, "B", 4, 0, 0));
            productMerchants.Add(new productMerchant(11, "B", 5, 0, 0));
            productMerchants.Add(new productMerchant(11, "B", 6, 0, 0));
    
            //foreach (var productMerchant in productMerchants)
            //    Console.WriteLine(productMerchant.productName + " - " + productMerchant.productID + " - " + productMerchant.qty);
    
            var results = productMerchants.GroupBy(g => g.productID)
                .Select(x => new
                {
                    id = x.Key,
                    sum = x.Sum(s => s.qty)
                });
    
            foreach (var result in results)
                Console.WriteLine(result.id + " - " + result.sum);
    
        }
