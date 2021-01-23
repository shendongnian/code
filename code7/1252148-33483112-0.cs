    public partial class MyEntity
    {
        public MyEntityId BadIdea { get; set; }
        [Key]
        public Guid Id 
        { 
           get 
           { 
                // needs null check
                return BadIdea.Value; 
           } 
           set 
           { 
               // needs null check
               BadIdea.Value = value; 
           }
        }
    }
