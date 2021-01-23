    // Use for JavaScriptSerializer
    using System.Web.Script.Serialization; 
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    List<myJSONClass> myList = serializer.Deserialize<List<myJSONClass>>(content);
    
    // Use for JsonConvert
    using Newtonsoft.Json;
    List<myJSONClass> myList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<myJSONClass>>(content);
