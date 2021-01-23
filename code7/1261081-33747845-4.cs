    public class MyPersonFacade : BindableBase
    {
        private Person _myPerson;
        private string _name;
        public string Name
        {
            get { return _myPerson.Name; }
            set 
            {
                _myPerson.Name = value;
                OnPropertyChanged();
            }
        } 
    }
