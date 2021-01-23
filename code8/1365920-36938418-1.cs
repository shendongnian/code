    public class Foo {
        public int FoodId { get; set; }
        public ICollection<MoreFoo> MoreFoo { get; set; }
        public int BarId { get; set; }
    }
    public class MoreFoo {
        public int FooId { get; set; }
        public Foo Foo { get; set; }
        public string SomeAttr { get; set; }
    }
    var modelBuilder = new DbModelBuilder();
           
    modelBuilder.Entity<MoreFoo>()
                    .HasRequired(x => x.Foo)
                    .WithMany(x => x.MoreFoo)
                    .HasForeignKey(x => x.FooId);
