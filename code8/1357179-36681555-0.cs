    class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            ToTable("Account");
            HasKey(x => x.ID);
            HasRequired(a => a.DateParams).WithRequiredPrincipal();
            HasRequired(a => a.Localization).WithRequiredPrincipal();
        }
    }
    
    class DateParamsMap : EntityTypeConfiguration<DateParams>
    {
        public DateParamsMap()
        {
            ToTable("Account");
        }
    }
    class LocalizationMap : EntityTypeConfiguration<Localization>
    {
        public LocalizationMap()
        {
            ToTable("Account");
        }
    }
    
