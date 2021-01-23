    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    var result = db.Persons.ToSelectList(p => p.Id, p => p.Name);
