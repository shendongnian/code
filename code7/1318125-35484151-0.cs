    using Newtonsoft.Json;
    public class JsonExample
        {
    
            private string jsonObject = "[{\"apple.com\": \"545\"}]".Trim();
    
            public JsonExample()
            { 
                DataTable items = JsonConvert.DeserializeObject<DataTable>(jsonObject);
            }
        }
