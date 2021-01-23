    public class People
    {
    public string Name { get; set; }
    public ICollection<People> PeopleList { get; set; }
    public People()
    {
    PeopleList = new List<People>();
    }
    }
    
    People people = new People(){Name = "Bob"};
    people.PeopleList.Add(new People() { Name = "Tom" });
    var s=  Newtonsoft.Json.JsonConvert.SerializeObject(people);
