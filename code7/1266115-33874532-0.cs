    public class MyObject 
    { 
        public string date { get; set ; }
    }
    string json = "{ \"date\": \"2015-11-23T00:00:00\" }";
    var myObj = JsonConvert.DeserializeObject<MyObject>(json);
    Console.WriteLine(myObj.date);
