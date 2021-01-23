    public class StudentViewModel : ViewModelBase
    {
        private string _name;
        private int _age;
        public string Name
        {
            get { return _name; }
            set { Set<string>(ref _name, value); }
        }
        public int Age
        {
            get { return _age; }
            set { Set<int>(ref _age, value); }
        }
    }
