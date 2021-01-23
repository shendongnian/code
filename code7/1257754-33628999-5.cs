    public partial class RequestMasterBusinessLogic
    {
        private YourDataContext Context;
        public RequestMasterBusinessLogic()
        {
            Context= new YourDataContext();
        }
        public List<RequestMaster> SelectAll()
        {
             Context.RequestMaster.Include("RequestType").ToList();
        }
        public List<Request> SelectAllRequests()
        {
             Context.RequestMaster
                    .Include("RequestType")
                    .Select(x => new Request()
                    {
                        RequestId = x.RequestId,
                        RequestType = x.RequestType,
                    }).ToList();
        }
    }
