    public class WebPlatformFactory : IPlatformFactory
    {
        IDataAccessFactory GetDataAccessFactory()
        {
            return new XmlDataAccessFactory();
        }
        IPricingFactory GetPricingFactory()
        {
            return new WebPricingFactory();
        }
    }
