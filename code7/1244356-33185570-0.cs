    Single: { "field1":"value1","field2":"value2" }
    Array: [ { "field1":"value1","field2":"value2" }, { "field1":"value1","field2":"value2" } ]
    public class Test
    {
      public string field1 { get; set; }
      public string field2 { get; set; } 
    }  
    Test myDeserializedObj = (Test)JavaScriptConvert.DeserializeObject(Request["jsonString"], typeof(Test));
    List<test> myDeserializedObjList = (List<test>)Newtonsoft.Json.JsonConvert.DeserializeObject(Request["jsonString"], typeof(List<test>));
