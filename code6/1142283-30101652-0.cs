    private Enum[] _NotSupportedTypes;
    public Enum[] NotSupportedTypes
    {
        get { return _NotSupportedTypes; }
        set {
            if (!Array.TrueForAll(value, x => x.GetType() == typeof(MyEnum)))
                throw new ArgumentException("All enums must be MyEnum");
            _NotSupportedTypes = value; 
        }
    }
