    public class Todo
    {
        public int ID { get; set; }
        //Foreign key
        public int StatusID { get; set; } //<====Add this line
        public virtual Status Status { get; set; }
    }
  
