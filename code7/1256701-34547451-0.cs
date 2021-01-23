    public class Email: ValueObjectBase<Email>
    {
        private readonly string _address;
        public Email(string address)
        {
            _address = address;
            Validate(); //check RegX
        }
    }
    public class FullName: ValueObjectBase<FullName>
    {
        private readonly string _firstName;
        private readonly string _lastName;
        public FullName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            this.Validate();
        }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
    }
    public class Account : EntityBase<Guid>, IAggregateRoot
    {
        public virtual FullName FullName { get; set; }
        public virtual Email Email { get; set; }
    }
