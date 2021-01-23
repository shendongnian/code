    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    string jsonString = "{'id':'54','name':'reza'}";
    JavaScriptSerializer j = new JavaScriptSerializer();
    Person person = j.Deserialize<Person>(jsonString);
    string id = person.id; // equals 54
