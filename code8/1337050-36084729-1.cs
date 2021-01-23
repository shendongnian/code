    public class SampleDbConfiguration : DbConfiguration
    {
        public SampleDbConfiguration()
        {
            // Set provider
            SetProvider();
        }
        /// <summary>
        /// Set Sql-Aynwhere as the current entity framework provider
        /// </summary>
        private void SetProvider()
        {
            // not required...
            this.SetDefaultConnectionFactory(new SampleDBConnectionFactory());
            this.SetProviderServices("iAnywhere.Data.SQLAnywhere", iAnywhere.Data.SQLAnywhere.SAProviderServices.Instance);
            this.SetProviderFactory("iAnywhere.Data.SQLAnywhere", iAnywhere.Data.SQLAnywhere.SAFactory.Instance);
        }
    }
