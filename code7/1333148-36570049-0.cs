    public class Transaction
    {
        public string TransactionID { get; set; }
        public string TransactionName { get; set; }
    }
    
    public class DBContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
    }
    
    public class TransactionService
    {
        public Transaction FindOrCreateTransactionByID(string id, DBContext db)
        {
            Transaction t = db.Transactions.SingleOrDefault(f => f.TransactionID == id);
            if (t == null)
            {
                t = new Transaction { TransactionID = id };
                db.Transactions.Add(t);
                db.SaveChanges();
            }
            return t;
        }
    }
    
    [TestClass]
    public class UnitTest
    {
        [TestMethod, Isolated]
        public void TestTransactionExist()
        {
            var service = new TransactionService();         
            string id = "id";
            string name = "name";
    
            var fakeDb = new DBContext();
            var fakeDbSet = Isolate.Fake.Instance<DbSet<Transaction>>();
    
            List<Transaction> data = new List<Transaction>()
            {
                new Transaction { TransactionID = id, TransactionName = name }
            };
    
            Isolate.WhenCalled(() => fakeDb.Transactions).WillReturnCollectionValuesOf(data.AsQueryable());
    
            Transaction res = service.FindOrCreateTransactionByID(id, fakeDb);
    
            Assert.AreEqual(name, res.TransactionName);
        }
    
        [TestMethod, Isolated]
        public void TestNewTransaction()
        {
            var service = new TransactionService();
            string id = "id";
    
            var fakeDb = new DBContext();
            var fakeDbSet = Isolate.Fake.Instance<DbSet<Transaction>>();
    
            List<Transaction> data = new List<Transaction>();
    
            Isolate.WhenCalled(() => fakeDb.Transactions).WillReturnCollectionValuesOf(data.AsQueryable());
            Isolate.WhenCalled(() => fakeDb.Transactions.Add(null)).DoInstead(
            context =>
            {
                data.Add(context.Parameters[0] as Transaction);
                return context.Parameters[0] as Transaction;
            });
    
            Transaction res = service.FindOrCreateTransactionByID(id, fakeDb);
    
            Assert.AreEqual(id, res.TransactionID);
        }
    }
