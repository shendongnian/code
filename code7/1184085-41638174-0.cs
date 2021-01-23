      using EntityFramework.OracleHelpers;
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
            this.ApplyAllConventionsIfOracle(modelBuilder);
      }
