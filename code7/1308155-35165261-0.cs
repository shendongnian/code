    public OptionalEntityConfiguration()
    {
       HasKey(r => r.RequiredEntityID);
       Property(r => r.RequiredEntityID)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    }
    public RequiredEntityConfiguration()
    {
       HasKey(r => r.ID);
       HasOptional(r => r.Optional);
    }
