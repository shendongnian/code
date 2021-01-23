    class Person
    {
        public string Name { get; set; }
    }
    class PersonFacade : BindableBase
    {
        Person _person;
        public string Name
        {
            get { return _person.Name; }
            set
            {
                _person.Name = value;
                OnPropertyChanged();
            }
        }
    }
    class ViewModel : BindableBase
    {
        private PersonFacade _person;
        public PersonFacade Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }
    }
