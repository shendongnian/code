      public class CustomerMap : EntityTypeConfiguration<Customer>
      {
        public CustomerMap()
        {
          // ....
          Property(x => x.Email).IsRequired().HasMaxLength(450).HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));
        }
      }
