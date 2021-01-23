    [Fact]
    public void Test1()
    {
        var kernel = new StandardKernel();
        kernel.Bind<RealContext>().To<FakeDbContext>();
        var result = kernel.Get<Wrapper>();
        var user = result.context.Users.Add(new User());
        Assert.NotNull(user);
    }
    public class Wrapper
    {
        public readonly RealContext context;
        public Wrapper(RealContext context)
        {
            this.context = context;
        }
    }
    public class RealContext : DbContext
    {
        public virtual IDbSet<User> Users => new UserDbSet();
    }
    public class FakeDbContext : RealContext
    {
        static FakeDbContext()
        {
            Database.SetInitializer<FakeDbContext>(null);
        }
        public override IDbSet<User> Users => new UserDbSet();
    }
    // .....
