    public class Case 
    {
        public string Name { get; set; }
        public int Number { get; set; }
        // other properties
        public override string ToString()
        {
            return Name + Number;
        }
        public override bool Equals(object obj)
        {
            Case other = obj as Case;
            if (other == null) return false;
            return other.ToString() == this.ToString();
        }
        public override int GetHashCode()
        {
            return (ToString() ?? "").GetHashCode();
        }
        // other methods
    }
