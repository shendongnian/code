    public class Person : DatabaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override bool Equals(object other)
        {
            if (!base.Equals(other))
                return false;
            Person person = (Person)other;
            return person.FirstName == FirstName && person.LastName == LastName;
        }
    }
