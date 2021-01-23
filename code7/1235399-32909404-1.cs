    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(){ProductID = 1});
            products.Add(new Product(){ProductID = 2});
            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction(){TransactionID = 10});
            trans.Add(new Transaction(){TransactionID = 20});
            trans.Add(new Transaction() { TransactionID = 50 });
            List<Connect> con = new List<Connect>();
            con.Add(new Connect(){TransactionID = 10, ProductID = 1});
            con.Add(new Connect(){TransactionID = 20, ProductID = 1});
            con.Add(new Connect() { TransactionID = 50, ProductID = 2 });
            
            var r1 = con.GroupBy(k => k.ProductID, k => trans.FirstOrDefault(q => q.TransactionID == k.TransactionID));
        }
    }
