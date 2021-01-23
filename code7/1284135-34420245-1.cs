    /// <summary>
    /// Interface for classes that define factory able to create currency defaltion instances.
    /// </summary>
    public interface ICurrencyDeflationFactory
    {
        List<ICurrencyDeflation> CurrencyList { get; }
        ICurrencyDeflation CreateInstance(string currencyCode);
    }
