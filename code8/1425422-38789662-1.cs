    public class ServiceLayer
    {
        IBusinessLayer business = null;
        public ServiceLayer(IBusinessLayer business)
        {
            this.business = business;
        }
        public void GetData()
        {
            Data data = business.GetData();
            // do something with data
        }
    }
