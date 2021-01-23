    public DbContext GetContext(DatabaseType dbType)
    {
        switch(dbType)
        {
            case DatabaseType.address:
                return new AddressContext();
            case DatabaseType.names:
                return new NamesContext();
            default:
                throw new ArgumentException("Unexpected db type.");
        }
    }
