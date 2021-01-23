            modelBuilder.Entity<Authority>()
                .HasMany(x => x.Broader)
                .WithMany()
                .Map(x => x.ToTable("AuthBroader"));
            modelBuilder.Entity<Authority>()
                .HasMany(x => x.Equivalent)
                .WithMany()
                .Map(x => x.ToTable("AuthEquivalent"));
            modelBuilder.Entity<Authority>()
                .HasMany(x => x.Narrower)
                .WithMany()
                .Map(x => x.ToTable("AuthNarrower"));
            modelBuilder.Entity<Authority>()
                 .HasMany(x => x.Related)
                 .WithMany()
                 .Map(x => x.ToTable("AuthRelated"));
            modelBuilder.Entity<Authority>()
                .HasMany(x => x.Use)
                .WithMany()
                .Map(x => x.ToTable("AuthUse"));
            modelBuilder.Entity<Authority>()
                .HasMany(x => x.Usefor)
                .WithMany()
                .Map(x => x.ToTable("AuthUsefor"));
