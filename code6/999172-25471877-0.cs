    public class Person  
    {
        public string Prename;
        public string Lastname;
      
        public Person(string pre, string last)
        {
            Prename = pre; Lastname = last;
        }
        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            //can make this check case insensitive using the overload
            return (Prename + Lastname).Equals(p.Prename + p.Lastname);
        }
        public override int GetHashCode()
        {
            return (Prename + Lastname).GetHashCode();
        }
    }
