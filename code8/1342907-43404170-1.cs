    public class MyApiController : ApiController
    {
        protected internal virtual JsonTextActionResult JsonText(string jsonText)
        {
            return new JsonTextActionResult(Request, jsonText);
        }
       
        [HttpGet]
        public IHttpActionResult GetJson()
        {
            string json = GetSomeJsonText();
            return JsonText(json);
        }
    }
