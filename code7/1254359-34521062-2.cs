    public class myClass
    {
        private _dataContext =new ServiceJobDataDataContext(_systemService.GetCurrentSystem().WriteOnlyDatabase.ConnectionString);
    
        public Domain.Data.ServiceJob SelectByServiceJobID(int serviceJobID)
        {
            using (_dataContext = new ServiceJobDataDataContext(_systemService.GetCurrentSystem().WriteOnlyDatabase.ConnectionString))
            {
             //...
            }  
        }
    }
