    public class MyViewModel : BindableBase
    {
        private Person _myPerson;
        public Person Person
        {
            get { return _myPerson; }
            set { SetProperty(ref _myPerson, value); }
        } 
    }
