    public class DataViewModel
    {
        //other stuff
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                RaisePropertyChanged("Age");
                RaisePropertyChanged("AgeVisibility");
            }
        }
        public Visibility AgeVisibility
        {
            get { return this.Age > 0 ? Visibility.Visible : Visibility.Hidden; }
        }
    }
