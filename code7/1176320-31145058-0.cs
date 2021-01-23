    public class Profile
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
        ...
    }
