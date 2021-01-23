    public class PersonViewModel: INotifyPropertyCahnged
    {
        private Person _Model;
        public Person Model
        {
            get { return _Model; }
            set
            {
                if(Equals(_Model, value) == true)
                   return;
                _Model = value;
                this.RaisePropertyChanged();
            }
            public String FullName {get {return _ModelFirstName + " " + _Model.LastName; }}
            public PersonViewModel(Person model)
            {
                _Model = model;
            }
        }
    }
