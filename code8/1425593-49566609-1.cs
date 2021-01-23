    private class Info
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public int Prop3 { get; set; }
        public bool Prop4 { get; set; }
    }
    var result = JObject.Parse(resultContent);   //parses entire stream into JObject, from which you can use to query the bits you need.
    var items = result["Items"].Children().ToList();   //Get the sections you need and save as enumerable (will be in the form of JTokens)
    
    List<Info> infoList = new List<Info>();  //init new list to store the objects.
    
    //iterate through the list and match to an object. If Property names don't match -- you could also map the properties individually. Also useful if you need to dig out nested properties.
    foreach(var subItem in items){
    foreach(JToken result in subItem){
    Info info = result.ToObject<Info>();
    infoList.add(info);
    }}
