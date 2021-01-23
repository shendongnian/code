    public static SomeBase someBaseProperty 
    {
        get { return GetBase(someBool); }
        private set(value) { _someBaseField = value; }
    }
