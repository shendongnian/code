    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public void GetPersonFromJson()
    {
        var json = " [{\"Name\":\"Jon\",\"Age\":\"30\"},{\"Name\":\"Smith\",\"Age\":\"25\"}]";
        var people = JsonConvert.DeserializeObject<List<Person>>(json);
    }
