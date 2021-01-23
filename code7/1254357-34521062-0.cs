    public class myClass
    {
        private _dataContext =new SomeDateContext(blah blah blah);
    
        public Domain.Data.ServiceJob SelectByServiceJobID(int serviceJobID)
        {
            using (_dataContext = new ServiceJobDataDataContext    (_systemService.GetCurrentSystem().WriteOnlyDatabase.ConnectionString))
            {
    
            }
    and 
