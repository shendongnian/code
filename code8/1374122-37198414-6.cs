    public DbSet<Speler> Spelers { get; set; }
        public DbSet<VoetbalPloeg> VoetbalPloegs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VoetbalPloeg>().HasMany(s => s.Spelers).WithRequired().HasForeignKey(h => h.VoetbalPloegId);
        }
