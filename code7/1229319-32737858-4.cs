    static Dictionary<SoapType, Type> _soaps = new Dictionary<SoapType, Type>
    {
        { SoapType.Beauty, typeof(BeautySoapFactory) }
        { SoapType.Detergent, typeof(DetergentSoapFactory) }
    };
    
    public ISoap CreateSoap(SoapType type) {
        return (ISoap)Activator.CreateInstance(_soaps[type]);
    }
