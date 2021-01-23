    class DbContex{
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Event> Events { get; set; }        
        public virtual DbSet<Session> Sessions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {       
        //Personally I would not have many requirements in the database unless I              
        //was completely sure it had to be that way.
        //They will ALWAYS bite you in the ass in the long run.
            modelBuilder.Entity<Event>(entity=> {
                entity.Property(e => e.Active).HasDefaultValue(false);
                entity.Property(e => e.EventCloseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1/1/2038'");
                entity.Property(e => e.Name).HasMaxLength(1024);
                entity.Property(e => e.PaxAllocationLimit).HasDefaultValue(10000);
            });
        
            modelBuilder.Entity<Brand>(entity => {
                entity.Property(e => e.Active).HasDefaultValue(false);    
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnType("varchar");                
            });
        
            modelBuilder.Entity<Session>(entity => {
                entity.Property(e=>e.Name)
                    .HasMaxLength(250)
                    .HasColumnType("varchar")
                    .HasDefaultValue("");    
                entity.Property(e => e.SessionDurationInMinutes)
                    .HasColumnType("numeric")
                    .HasDefaultValue(0m);                
                });
            }
        }
    }
