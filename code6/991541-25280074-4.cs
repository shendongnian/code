    public class MyWebApiController : ApiController
    {
        public string Get()
        {
            var url = this.Url.Link("Default", new { Controller = "MyMvc", Action = "MyAction", param1 = 1, param2 = "somestring" });
            return url;
        }
    }
