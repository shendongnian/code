    public class PersonViewModel : PropertyChangedBase
    {
        private PersonModel _Person;
        public string FirstName
        {
            get { return _Person.FirstName; }
            set
            {
                _Person.FirstName = value;
                NotifyOfPropertyChange();
            }
        }
        public string LastName
        {
            get { return _Person.LastName; }
            set
            {
                _Person.LastName = value;
                NotifyOfPropertyChange();
            }
        }
        //TODO: Your command goes here
        public PersonViewModel()
        {
            //TODO: Get your model from somewhere.
            _Person = new PersonModel();
        }
    }
