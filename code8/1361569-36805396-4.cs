    public interface IPerson
    {
        string FirstName { get; }
        string MiddleName { get; }
        string LastName { get; }
    }
    public class Person : IPerson
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        //Make sure the parameterless constructor is private
        private Person() { }
        private Person(string first, string middle, string last)
        {
            this.FirstName = first;
            this.MiddleName = middle;
            this.LastName = last;
        }
        public class Builder
        {
            private Person person = new Person();
            public Builder WithFirstName(string first)
            {
                person.FirstName = first;
                return this;
            }
            public Builder WithMiddleName(string middle)
            {
                person.MiddleName = middle;
                return this;
            }
            public Builder WithLastName(string last)
            {
                person.LastName = last;
                return this;
            }
            public IPerson Build()
            {
                if (person.FirstName != null && person.MiddleName != null && person.LastName != null)
                    return person;
                throw new Exception("Cannot build person because reasons...");
            }
        }
    }
