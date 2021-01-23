    public class TestController : ApiController
    {
    
        private cdwEntities db = new cdwEntities();
    
        private Query respository;
    
        [HttpGet]
        public HttpResponseMessage getData()
        {
           //Calling the static method in Query class
           var details = Query.BindDatatable();
           //Your code here
        }
    }
