    public class Subject
    {
        [Key]
        public string Name { get; set; }
        /* other properties if needed */
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
