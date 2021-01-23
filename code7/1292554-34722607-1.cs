    public class Customer : ModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public override IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName) || propertyName == nameof(Name))
            {
                if (string.IsNullOrWhiteSpace(_name))
                    yield return "Name cannot be empty.";
            }
        }
    }
    public class CustomerWithAge : Customer
    {
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }
        public override IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            foreach (var obj in base.GetErrors(propertyName))
            {
                yield return obj;
            }
            if (string.IsNullOrEmpty(propertyName) || propertyName == nameof(Age))
            {
                if (_age <= 0)
                    yield return "Age is invalid.";
            }
        }
    }
