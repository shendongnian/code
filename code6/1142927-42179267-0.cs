    public class TestController : ApiController
    {
        [HttpGet]
        public List<string> GetAll()
        {
            return new List<string>();
        }
        [HttpGet]
        public string Get(int id)
        {
            return string.Empty;
        }
        [HttpGet]
        public string GetSmthByParam1(int id)
        {
            return string.Empty;
        }
        [HttpGet]
        public string GetSmthByParam2(int id)
        {
            return string.Empty;
        }
        [HttpGet]
        public List<string> GetAllByParam(int id)
        {
            return new List<string>();
        }
    }
