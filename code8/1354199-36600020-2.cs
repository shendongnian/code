        public class NamedPersonSpecification : AbstractSpecification<Person>
    {
        private string _name;
        public NamedPersonSpecification(string name)
        {
            this._name= name;
        }
        public override bool IsSatisfiedBy(Person o)
        {
            return o.Name.Equals(_name);
        }
    }
