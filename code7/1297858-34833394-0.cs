    public class Results
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public override bool Equals(object obj)
        {
            Results other = obj as Results;
            if (other == null)
                return false;
            return other.Prop1 == this.Prop1 && other.Prop2 == this.Prop2;
        }
        public override int GetHashCode()
        {
            return new {Prop1, Prop2}.GetHashCode();
        }
    }
