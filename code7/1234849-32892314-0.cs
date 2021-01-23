    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    ...
    dynamic jsonObject = new JObject();
    jsonObject.keyName1 = "XXX";
    jsonObject.keyName2 = 180539;
    jsonObject.keyName3 = new JArray() as dynamic;
    dynamic jsonArrayObject = new JArray() as dynamic;
    dynamic jsonObject2 = new JObject();
    jsonObject2.what = "xxxxx";
    jsonArrayObject.Add(jsonObject2);
    jsonObject2 = new JObject();
    jsonObject2.what = "yyyyy";
    jsonObject2.duration = 30;
    jsonArrayObject.Add(jsonObject2);
    jsonObject2 = new JObject();
    jsonObject2.what = "zzzz";
    jsonArrayObject.Add(jsonObject2);
    var jsonArrayString = JsonConvert.SerializeObject(jsonArrayObject, Formatting.None);
           
    jsonObject.keyName3 = jsonArrayString;
    jsonObject.keyName4 = "123";
    string json = JsonConvert.SerializeObject(jsonObject, Formatting.None);
