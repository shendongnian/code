    public class ClassA
        {
            public ClassA()
            {
                AId = Guid.NewGuid().ToString();
    
            }
            [Key]
            public string AId { get; set; }
    
    
        }
