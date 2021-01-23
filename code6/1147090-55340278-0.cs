    class MyEntityConfiguration : EntityTypeConfiguration<MyEntity>
        {
            public MyEntityConfiguration()
            {
                Property(e => e.MyDateTimeWithPrecision)
                    .HasPrecision(6);
             }
         }
