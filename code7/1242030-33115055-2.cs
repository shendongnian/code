    public class PersonBuilder:Builder<Person, PersonBuilder>
    {
        public PersonBuilder():base()
        {
        }
        public PersonBuilder Name(string name)
        {
            model.Name = name;
            return this;
        }
        public PersonBuilder Age(int age)
        {
            model.Age = age;
            return this;
        }
    }
