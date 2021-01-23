    public class Transaction
    {
        public string TransactionID { get; set; }
    }
    public class DBContext : DbContext
    {
        public virtual DbSet<Transaction> Transactions { get; set; }
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
    [TestFixture]
    public class TransactionServiceTests
    {
        [Test]
        public void When_transaction_not_found_new_transaction_created()
        {
            const string id = "_id_";
            var mockSet = new Mock<DbSet<Transaction>>();
            // setup data
            IQueryable<Transaction> data = new List<Transaction>().AsQueryable();
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
            var mockContext = new Mock<DBContext>();
            mockContext.SetupGet(x => x.Transactions).Returns(mockSet.Object);
            var service = new TransactionService();
            service.FindOrCreateTransactionByID(id, mockContext.Object);
            mockSet.Verify(
                set => set.Add(It.Is<Transaction>(t => t.TransactionID == id)), 
                Times.Once);
            mockContext.Verify(context => context.SaveChanges(), Times.Once);
        }
    }
