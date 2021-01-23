    public class SampleDataContext : DbContext,IUserDbContext
    {
            
        public DbSet<SampleUser> Users { get; set; }
        
        
        private IDbSet<SampleUser, int> _userSet;
        public IDbSet<SampleUser, int> UserSet
            {
                get { return _userSet ?? (_userSet = new UserInterface() { Db = this }); }
                set { _userSet = value; }
            }
        public class UserInterface : IDbSet<SampleUser, int>
            {
                public SampleDataContext Db { get; set; }
    
                public SampleUser Add() => Db.Users.Add(new SampleUser());
    
                public IQueryable<SampleUser> All() => Db.Users;
    
                public SampleUser Get(int id) => Db.Users.Find(id);
    
                public void Delete(int id) => Db.Users.Remove(Get(id));
            }
    }
