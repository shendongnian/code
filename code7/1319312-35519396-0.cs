    public class User 
    {
        // ... other properties
        public virtual ICollection<ToDo> ToDos { get; set; }
    }
