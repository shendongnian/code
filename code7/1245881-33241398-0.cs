    public class CustomComplexTypeAttributeConvention : ComplexTypeAttributeConvention {
        public CustomComplexTypeAttributeConvention(){
           Properties().Configure(p => p.HasColumnName(p.ClrPropertyInfo.Name));
        }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder){
       modelBuilder.Conventions.Remove<ComplexTypeAttributeConvention>();
       modelBuilder.Conventions.Add(new CustomComplexTypeAttributeConvention());
       //...
    }
