    public class MyDataContext : DbContext, IUserDbContext
    {
        public DbSet<MyUser> Users { get; set; }
        
    
        private IDbSet<SampleUser, int> _userSet;
        public IDbSet<SampleUser, int> UserSet
            {
                get { return _userSet ?? (_userSet = new UserInterface() { Db = this }); }
                set { _userSet = value; }
            }
        public class UserInterface : IDbSet<SampleUser, int>
            {
                public MyDataContext Db { get; set; }
    
                public SampleUser Add() => Db.Users.Add(new MyUser());
    
                public IQueryable<SampleUser> All() => Db.Users;
    
                public SampleUser Get(int id) => Db.Users.Find(id);
    
                public void Delete(int id) => Db.Users.Remove(Db.Users.Find(id)??new MyUser());
            }
    }
    
    
    [Table("Users")]
    public class MyUser : SampleUser
    {
        public string Color { get; set; }
    
        public override string ToString()
        {
            return base.ToString() + $"/ color : {Color}";
        }
    }
