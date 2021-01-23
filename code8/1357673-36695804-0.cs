    public class Assignment
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        
        // This is just one of many ways to do it.
        // This can be an extension method, for example.
        // Note also that DateTime.UtcNow is changing as 
        // you are traversing the list.
        public bool IsOverdue
        {
           get { return DateTime.UtcNow > DueDate; }
        }
    }
