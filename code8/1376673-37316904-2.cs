    public partial class RealDataContext : DataContext, IMyDataContext
    {
         DbSet<SomeEntity> SomeEntities { get; set; }
    
        /* Contructor, Initialization code, etc... */
    }
    
    public class FakeDataContext : DataContext, IMyDataContext
    {
         DbSet<SomeEntity> SomeEntities { get; set; }
    
        /* Mocking, test doubles, etc... */
    }
