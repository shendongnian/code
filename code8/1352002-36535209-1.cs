        public class PersonConfig:EntityTypeConfiguration<Person>
        {
            public PersonConfig()
            {
                HasOptional(t => t.User).WithRequired().WillCascadeOnDelete();
            }
        }
