    public class UploadRequest : JObject
    {
       [JSONProperty("<name of the property in the JSON object>")]
       public JArray pdfs { get; set; }
    }
