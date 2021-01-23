    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    string jsonString = "{'id':'54','name':'reza'}";
    JavaScriptSerializer j = new JavaScriptSerializer();
    var person = j.Deserialize<Person>(jsonString);
    var id = person.id; // equals 54
