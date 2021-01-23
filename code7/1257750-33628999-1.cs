    public partial class RequestMasterBusinessLogic
    {
        private YourDataContext Context;
        public RequestMasterBusinessLogic()
        {
            Context= new YourDataContext();
        }
        public List<Request> SelectAll()
        {
             //....
        }
    }
