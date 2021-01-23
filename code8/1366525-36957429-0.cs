    public class Tag : IEquatable<Tag>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Equals(Tag other)
        {
            return Id == other.Id && Name == other.Name;
        }
        ...
    }
    
