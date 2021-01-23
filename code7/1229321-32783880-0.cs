    public ISoap CreateSoap(ProductType type)
    {
        switch (type)
        { 
            case ProductType.BeautySoap:
                return new BeautySoapFactory();
            case ProductType.DetergentSoap:
                return new DetergentSoapFactory();
            default:
                throw new ApplicationException(string.Format("Soap '{0}' cannot be created", type));
                //Console.WriteLine(string.Format("Soap '{0}' cannot be created", name));
                //break;
        }
    }
