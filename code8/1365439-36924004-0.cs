    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public void GetPersonFromJson()
    {
        var json = " [{\"Name\":\"Jon\",\"Age\":\"30\"},{\"Name\":\"Smith\",\"Age\":\"25\"}]";
    
        JavaScriptSerializer oJS = new JavaScriptSerializer();
        Person[] person = oJS.Deserialize<Person[]>(json);
    }
