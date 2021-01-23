    var jsonSerializer = new JavaScriptSerializer();
    var jsonString = /*your json string*/
       
    var yourList = jsonSerializer.Deserialize<List<YourClass>>(jsonString);
    
    public class YourClass
    {
        public string 0 { get; set; }
        public string 1 { get; set; }
    }
