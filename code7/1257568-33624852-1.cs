    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person person;
    
        private ICommand updateCommand;
    
        public PersonViewModel()
        {
            this.Person = new Person();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public Person Person
        {
            get
            {
                return this.person;
            }
    
            set
            {
                this.person = value;
    
                // if you use VS 2015 or / and C# 6 you also could use
                // this.OnPropertyChanged(nameof(Person));
                this.OnPropertyChanged("Person");
            }
        }
    
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand<Person>(this.OpenMessageBox, this.OpenMessageBoxCanExe);
                }
    
                return this.updateCommand;
            }
        }
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        private void OpenMessageBox(Person person)
        {
            MessageBox.Show("Hola");
        }
    
        private bool OpenMessageBoxCanExe(Person person)
        {
            if (person == null)
            {
                return false;
            }
    
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
            {
                return false;
            }
    
            return true;
        }
    }
