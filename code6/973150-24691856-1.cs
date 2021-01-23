    public class MyConfiguration : DbConfiguration 
    { 
        public MyConfiguration() 
        { 
            SetProviderServices( 
                SqlCeProviderServices.ProviderInvariantName, 
                SqlCeProviderServices.Instance); 
        } 
    }
