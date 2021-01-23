    public class StuffController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<SomeModel> models = ReadModels();
            return GetJsonResponse(models);
        }
    }
    public static HttpResponseMessage GetJsonResponse(object serializableObject)
    {
        string jsonText = JsonConvert.SerializeObject(serializableObject, Formatting.Indented);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(jsonText, Encoding.UTF8, "text/plain");
    
        return response;
    }
