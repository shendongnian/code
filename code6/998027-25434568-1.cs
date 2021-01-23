    public class Estimate {
       public string Name { get; set; }
       public List<Option> Options { get; set; }
    
       public Estimate() {
          Options = new List<Option>();
       }
    }
    
    public class Option {
       public int Id { get; set; }
       public string Description { get; set; }
       public Estimate Estimate { get; set; }
    }
