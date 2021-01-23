    class EquatableThing 
    {
        public string Name { get; set; }
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Name == ((EquatableThing)other).Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
