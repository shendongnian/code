    public interface IPlatformFactory
    {
        IDataAccessFactory GetDataAccessFactory();
        IPricingFactory GetPricingFactory();
    }
