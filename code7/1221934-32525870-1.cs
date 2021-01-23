    var jsonSerializer = new JavaScriptSerializer();
    var jsonString = /*your json string*/
       
    var yourList = jsonSerializer.Deserialize<List<YourClass>>(jsonString);
    
    public class YourClass
    {
        public string Zero { get; set; }
        public string One { get; set; }
    }
