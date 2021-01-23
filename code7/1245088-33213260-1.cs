    public UserEntityMap : ClassMap<UserEntity>
    {
       //Other properties
       HasMany(x => x.Addresses)
           .KeyColumn("User_id").Fetch.Join()
           .BatchSize(100);
       HasMany(x => x.Roles)
           .KeyColumn("User_id").Fetch.Join()
           .BatchSize(100);
    }
