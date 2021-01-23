		public DbSet<MenuViewModel> Menus { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
