    public class Resource()
    {
         public int ID { get; set; }
         .......
    }
    public class Profile()
    {
         public int ID { get; set; } 
         .....
         public Resource Resource { get; set; }
    }
