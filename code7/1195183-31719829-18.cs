    using Newtonsoft.Json.Linq;
    public class TestController : ApiController
    {
        [HttpPost]
        public string SomeThing(JObject obj)
        {
            return obj["name"] + " bla " + obj["age"];
        }
    }
