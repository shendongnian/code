    var myObj = new object();
    List<Dictionary<string, object>> container = new List<Dictionary<string, object>>()
    {
        new Dictionary<string, object> { { "Text", "Hello world" } }
    };
    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
    var converter = new ExpandoObjectConverter();
    var obj = JsonConvert.DeserializeObject<IEnumerable<ExpandoObject>>(json_serializer.Serialize(container), converter);
    return View(obj);
