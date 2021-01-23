    public class People
    {
       public int Id { get; set; }
       public string Forename { get; set; }
       public string Surname { get; set; }
       public Hobby Hobby { get; set; }
    }
    
    public class Hobby
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public ICollection<People> People { get; set; }
    }
