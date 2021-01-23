     public class Suggestion {
            public int Id { get; set; } 
            public string Comment { get; set; } 
            public DateTime WhenCreated { get; set; } 
        }
    
        var n = new Suggestion();
        n.WhenCreated = DateTime.Now;
