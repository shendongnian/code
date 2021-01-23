    public class Foo {
        public int FoodId { get; set; }
        public MoreFoo MoreFoo { get; set; }
        public int BarId { get; set; }
    }
    public class MoreFoo {
        public Foo Foo { get; set; }
        public string SomeAttr { get; set; }
    }
    var modelBuilder = new DbModelBuilder();
           
    modelBuilder.Entity<MoreFoo>()
                        .HasRequired(x => x.Foo)
                        .WithOptional(x => x.MoreFoo)
                        .Map(x => x.MapKey("FooId"));
