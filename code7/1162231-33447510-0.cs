    public interface IProductSettingsRepositoryFactory
    {
        ProductSettingsRepository Create(string productCode);
    }
    public class ProductSettingsRepositoryFactory : IProductSettingsRepositoryFactory
    {
        public ProductSettingsRepository Create(string productCode)
        {
            return new ProductSettingsRepository(
                ServiceLocator.Current.GetInstance<ILogWriter>(),
                ServiceLocator.Current.GetInstance<ISecurityFunctionRepository>(),
                ServiceLocator.Current.GetInstance<IProductSettingsManager>(),
                ServiceLocator.Current.GetInstance<IReferenceDataService>(),
                productCode);
        }
    }
