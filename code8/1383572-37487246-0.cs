    public class DataContextConfiguration : DbConfiguration
    {
        public DataContextConfiguration()
        {
            SetContextFactory(() => (DataContext)new CompositionManager().Container.GetExportedValue<IDataContextFactory>().Create());
        }
    }
