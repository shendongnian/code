    class Factory 
    {
        public ISoap CreateSoap(ProductType type)
        {
            switch (type)
            {
                case ProductType.BeautySoap:
                    return new BeautySoapFactory();
                case ProductType.DetergentSoap:
                    return new DetergentSoapFactory();
                default:
                    throw new ApplicationException();
            }
        }
    }
