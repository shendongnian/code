    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, this))
                return true;
            Person other = obj as Person;
            if (other == null)
                return false;
            return other.Id == this.Id;
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
