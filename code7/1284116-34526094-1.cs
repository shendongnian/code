            modelBuilder.Entity<PropertyBase>()
                .HasKey(p => p.PropertyID)
                .ToTable("Properties");                    
            modelBuilder.Entity<IntProperty>()
                .ToTable("IntProperties");
            modelBuilder.Entity<TextProperty>()
                .ToTable("TextProperties");
