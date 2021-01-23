    namespace Joukyuu.Models
    {
        public class Passage
        {
            public int PassageId { get; set; }
            public string Contents { get; set; }
    
    
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
           public Passage()
           {          
             this.CreatedDate  = DateTime.UtcNow;
             this.ModifiedDate = DateTime.UtcNow;
           }
        }
    }
