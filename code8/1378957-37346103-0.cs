      public ActionResult Method(object[] data)
      {
            var productList = Helpers.Json.ParseJsonObjectToJArray(data, "productList");
    
            if(jArray.Count > 0)
            {
    
            }
        }
        
        public class Json
        {
            public static JArray ParseJsonObjectToJArray(object[] data, string objectName)
            {
                 dynamic jObject = JObject.Parse(data[0].ToString());
                 var info = jObject[objectName];
        
                 return info;
            }
       }
