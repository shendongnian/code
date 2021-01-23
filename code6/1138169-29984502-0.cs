    public class BaseClassConfiguration : EntityTypeConfiguration<BaseClass> {
        public BaseClassConfiguration()
            : base() {
            ToTable("BaseClasses", "dbo");
            //HasKey(tp => tp.Id);
            
            Map<Derived1>(m => m.Requires("dis").HasValue("C"));
            Map<Derived2>(m => m.Requires("dis").HasValue("I"));
            Map<Derived3>(m => m.Requires("dis").HasValue("R"));
            Map<Derived3>(m => m.Requires("dis").HasValue("U"));
        }
    }
