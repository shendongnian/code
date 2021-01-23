    public class PersonsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> persons = new ObservableCollection<Person> { new Person { Name = "Bjarne balblablalblalbal balbalbalballblalbla" }, new Person { Name = "Arne Belinda blblabllalbalblllablalbla Arne Belinda blblabllalbalblllablalbla Arne Belinda blblabllalbalblllablalbla Arne Belinda blblabllalbalblllablalbla Arne Belinda blblabllalbalblllablalbla" }, new Person { Name = "Turid" } };
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set
            {
                if (Equals(value, persons)) return;
                persons = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator] // No R#? Comment this line out
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
