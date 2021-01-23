    public class Column : IEquatable<Column>
    {
        public string Name { get; set; }
    
        public bool Equals( Column other )
        {
            // consider case insensitive comparison if needed.
            return Name == other.Name;
        }
    }
