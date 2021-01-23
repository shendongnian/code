    public interface IPlatformFactory
    {
        IDataAccessFactory GetDataAccessFactory();
        IPricingFactory GetPricingFactory(); // might be in the business project, or another project referenced by it
    }
