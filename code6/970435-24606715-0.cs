    [TypeConverter(typeof(TypeNameConverter))]
    [ConfigurationProperty("BackingStoreProvider", IsRequired = true)]
    public IBackingStore BackingStoreProvider
    {
        get
        {
            var type = this["BackingStoreProvider"].ToString().Replace(" ", "").Split(',');
            IBackingStore backingStore = (IBackingStore) Activator.CreateInstance(this["BackingStoreProvider"] as Type);
            return backingStore;
        }
    }
