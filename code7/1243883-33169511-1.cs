    [ChangeFormatterAttribute(typeof(JsonMediaTypeFormatter))]
    public class HomeController : ApiController
    {
        public string Get()
        {
            return "ok";
        }
    }
    // ...
    [ChangeFormatterAttribute(typeof(XmlMediaTypeFormatter))]
    public class ValuesController : ApiController
    {
        public string Get()
        {
            return "ok";
        }
    }
