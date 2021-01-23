    private static Lazy<StringCollection> privateBananaTypes = new Lazy<StringCollection>(GetBananaTypesCollection);
    public static StringCollection BananaTypes
    {
        get { return privateBananaTypes.Value; }
    }
    private static Lazy<StringCollection> privateFlowerTypes = new Lazy<StringCollection>(GetFlowerTypesCollection);
    public static StringCollection FlowerTypes
    {
        get { return privateFlowerTypes.Value; }
    }
