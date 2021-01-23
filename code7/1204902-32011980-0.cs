    public abstract class TPHBase
    {
        public int ID { get; set; }
        public string CommonProperty { get; set; }
    }
    public class TPHChild1 : TPHBase
    {
        public string Child1Property { get; set; }
    }
    public abstract class TPHChild2 : TPHBase
    {
        public int? Child2Property { get; set; }
    }
    public class TPHChild3 : TPHChild2
    {
        public int? Child3Property { get; set; }
    }
    public class TPHChild4 : TPHChild2
    {
        public int? Child4Property { get; set; }
    }
    protected override void OnModelCreating( DbModelBuilder modelBuilder )
    {
        modelBuilder.Entity<TPHBase>()
                .ToTable( "TPHBase" )
                .Map<TPHChild1>( m => m.Requires( "Dyskryminator" ).HasValue( "c1" ) )
                .Map<TPHChild3>( m => m.Requires( "Dyskryminator" ).HasValue( "c3" ) )
                .Map<TPHChild4>( m => m.Requires( "Dyskryminator" ).HasValue( "c4" ) );
        ...
