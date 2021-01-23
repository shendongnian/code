    #region Method Overrides
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EFUser>();
        var terminalConfig = modelBuilder.Entity<TerminalEx>();
    
        //terminalConfig.Map(b => 
        //{
        //    b.Property(c => c.Name).HasColumnName("TerminalName");
        //    b.Property(c => c.UseAutoAddDriverPayment).HasColumnName("useAutoAddlDrvPmt");
        //    b.Property(c => c.AutoPopulateAccountNumberForOrderEntry).HasColumnName("OEautoPopulateAccountNo");
        //    b.Property(c => c.AutoPopulateAddressesForOrderEntry).HasColumnName("OEautoPopulateAddresses");                
        //}).ToTable("Terminals", "dbo").HasKey(d => d.TerminalId);
    
        // base.OnModelCreating(modelBuilder);
    }        
    #endregion
