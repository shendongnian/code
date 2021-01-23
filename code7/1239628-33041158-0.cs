        }
        #endregion
        #region Properties
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<StatutPersonne> StatutsPersonne { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Lieu> Lieux { get; set; }
        public DbSet<CategorieEvenement> CategoriesEvenement { get; set; }
        #endregion
        #region Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("AGENDACTCS");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Personne>().
                HasMany(t => t.Evenements).
                WithMany(t => t.Personnes).
                Map(
                m =>
                {
                    m.MapLeftKey("ID_PERSONNE");
                    m.MapRightKey("ID_EVENEMENT");
                    m.ToTable("RESERVATION");
                });
            base.OnModelCreating(modelBuilder);  
        }
