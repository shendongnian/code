    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public TaskConfig()
        {
            ToTable("tblPerson");
    
            HasKey(s => s.Id);
    
            Property(s => s.Id)
                .HasColumnName("idPerson");
    
            Property(s => s.Name)
                .HasColumnName("strName")
                .IsRequired();
    
            HasOptional(a => a.Car)
                .WithRequired(s => s.Person);
        }
    }
    
    public class CarConfig : EntityTypeConfiguration<Car>
    {
        public CarConfig()
        {
            ToTable("tblCar");
    
            HasKey(s => s.PersonId)
                .Property(s => s.PersonId)
                .HasColumnName("idPerson");
    
            Property(s => s.Model)
                .HasColumnName("strModel")
                .IsRequired();
    
            //not necessary
            //HasRequired(a => a.Person)
                //.WithRequiredDependent();
        }
    }
