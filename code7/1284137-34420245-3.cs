    public class CurrencyDeflationFactory : ICurrencyDeflationFactory
    { 
        List<ICurrencyDeflation> deflationCollection;
        public CurrencyDeflationFactory(List<ICurrencyDeflation> definedDeflations)
        {
            this.deflationCollection = definedDeflations;
        }
        public List<ICurrencyDeflation> CurrencyList
        {
            get
            {
                return deflationCollection;
            }
        }
        public ICurrencyDeflation CreateInstance(string currencyCode)
        {
            return deflationCollection.Find(x => x.CurrencyCode.Equals(currencyCode));
        }
    }
