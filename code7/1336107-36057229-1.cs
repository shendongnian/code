    public class FooController: ApiController
    {
        [HttpPost]
        public string Post(string id)
        {
            return "String";
        }
    
        [HttpPost]
        public string Post(List<string> id)
        {
            return "some list";
        }
    }
