    public class Bus
    {
       public Bus()
       {
           ServiceNumbers = new List<string>();
       }
    
       public DateTime Date {get; set;}
       public int ServiceNumber {get; set;}
       public List<string> ServiceNumbers {get; set;}
    }
