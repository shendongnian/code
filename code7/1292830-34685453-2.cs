    public class PersonViewModel : ViewModelBase
    {
        private readonly Person person = new Person();
        public string Name
        {
            get { return person.Name; }
            set
            {
                person.Name = value;
                OnPropertyChanged(() => Name);
            }
        }
        public double Age
        {
            get { return person.Age; }
            set
            {
                person.Age = value;
                OnPropertyChanged(() => Age);
            }
        }
    }
