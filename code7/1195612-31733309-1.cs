    public class BusinessService : IBusinessService
    {
        private DbContext db;
        public BusinessService(DbContext db)
        {
            this.db = db;
        }
        public decimal GetBranchGrossTotal(int id, string revenueLoanType)
        {
            var branch = db.Branch.First(b => b.Id == id);
            // do stuff
            return total;
        }
    }
