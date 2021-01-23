    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    
        public override bool Equals (Object obj)
        {
            Person otherPerson = obj as Person;
            return otherPerson != null 
                && otherPerson.Name == Name 
                && otherPerson.Age == Age;
        }
    
        // http://stackoverflow.com/a/263416/284240
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (Name?.GetHashCode() ?? 0); // or: hash = hash * 23 + (Name == null ? 0 : Name.GetHashCode());
                hash = hash * 23 + Age; ;
                return hash;
            }
        }
    }
