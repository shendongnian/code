    public class Project
    {
        public Project()
        {
            this.DateTimeUpdated = DateTime.Now; 
            // This will be update in Init. Or assign as constructor param
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }
    }
