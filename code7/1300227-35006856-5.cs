    // Data models
    
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
    }
    
    public class DataPool
    {
        public static string GenerateFirstName(Random random)
        {
            List<string> names = new List<string>() { "Lilly", "Mukhtar", "Sophie", "Femke", "Abdul-Rafi", "Mariana", "Aarif", "Sara", "Ibadah", "Fakhr", "Ilene", "Sardar", "Hanna", "Julie", "Iain", "Natalia", "Henrik", "Rasa", "Quentin", "Gadi", "Pernille", "Ishtar", "Jimmy", "Justine", "Lale", "Elize", "Randy", "Roshanara", "Rajab", "Marcus", "Mark", "Alima", "Francisco", "Thaqib", "Andreas", "Marianna", "Amalie", "Rodney", "Dena", "Amar", "Anna", "Nasreen", "Reema", "Tomas", "Filipa", "Frank", "Bari'ah", "Parvaiz", "Jibran", "Tomas", "Elli", "Carlos", "Diego", "Henrik", "Aruna", "Vahid", "Eliana", "Roxanne", "Amanda", "Ingrid", "Wesley", "Malika", "Basim", "Eisa", "Alina", "Andreas", "Deeba", "Diya", "Parveen", "Bakr", "Celine", "Daniel", "Mattheus", "Edmee", "Hedda", "Maria", "Maja", "Alhasan", "Alina", "Hedda", "Vanja", "Robin", "Victor", "Aaftab", "Guilherme", "Maria", "Kai", "Sabien", "Abdel", "Jason", "Bahaar", "Vasco", "Jibran", "Parsa", "Catalina", "Fouad", "Colette", "John", "Fred", "James", "Harry", "Ben", "Steven", "Philip", "Dougal", "Jasper", "Elliott", "Charles", "Gerty", "Sarah", "Sonya", "Svetlana", "Dita", "Karen", "Christine", "Angela", "Heather", "Spence", "Graham", "David", "Bernie", "Darren", "Lester", "Vince", "Colin", "Bernhard", "Dieter", "Norman", "William", "Nigel", "Nick", "Nikki", "Trent", "Devon", "Steven", "Eric", "Derek", "Raymond", "Craig" };
            return names[random.Next(0, names.Count)];
        }
        public static string GenerateLastName(Random random)
        {
            List<string> lastnames = new List<string>() { "Carlson", "Attia", "Quincey", "Hollenberg", "Khoury", "Araujo", "Hakimi", "Seegers", "Abadi", "Krommenhoek", "Siavashi", "Kvistad", "Vanderslik", "Fernandes", "Dehmas", "Sheibani", "Laamers", "Batlouni", "Lyngvær", "Oveisi", "Veenhuizen", "Gardenier", "Siavashi", "Mutlu", "Karzai", "Mousavi", "Natsheh", "Nevland", "Lægreid", "Bishara", "Cunha", "Hotaki", "Kyvik", "Cardoso", "Pilskog", "Pennekamp", "Nuijten", "Bettar", "Borsboom", "Skistad", "Asef", "Sayegh", "Sousa", "Miyamoto", "Medeiros", "Kregel", "Shamoun", "Behzadi", "Kuzbari", "Ferreira", "Barros", "Fernandes", "Xuan", "Formosa", "Nolette", "Shahrestaani", "Correla", "Amiri", "Sousa", "Fretheim", "Van", "Hamade", "Baba", "Mustafa", "Bishara", "Formo", "Hemmati", "Nader", "Hatami", "Natsheh", "Langen", "Maloof", "Patel", "Berger", "Ostrem", "Bardsen", "Kramer", "Bekken", "Salcedo", "Holter", "Nader", "Bettar", "Georgsen", "Cuninho", "Zardooz", "Araujo", "Batalha", "Antunes", "Vanderhoorn", "Srivastava", "Trotter", "Siavashi", "Montes", "Sherzai", "Vanderschans", "Neves", "Sarraf", "Kuiters", "Hestoe", "Cornwall", "Paisley", "Cooper", "Jakoby", "Smith", "Davies", "Jonas", "Bowers", "Fernandez", "Perez", "Black", "White", "Keller", "Hernandes", "Clinton", "Merryweather", "Freeman", "Anguillar", "Goodman", "Hardcastle", "Emmott", "Kirkby", "Thatcher", "Jamieson", "Spender", "Harte", "Pinkman", "Winterman", "Knight", "Taylor", "Wentworth", "Manners", "Walker", "McPherson", "Elder", "McDonald", "Macintosh", "Decker", "Takahashi", "Wagoner" };
            return lastnames[random.Next(0, lastnames.Count)];
        }
        public static string GenerateState(Random random)
        {
            List<string> states = new List<string>() { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "District Of Columbia", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
            return states[random.Next(0, states.Count)];
        }
    }
    
    public class Cache
    {
        public Cache()
        {
            InitializeCacheData();
            SimulateLiveChanges(new TimeSpan(0, 0, 1));
        }
    
        public ObservableCollection<Contact> Contacts { get; set; }
    
        private static Random rnd = new Random();
    
        private void InitializeCacheData()
        {
            Contacts = new ObservableCollection<Contact>();
    
            var i = 0;
            while (i < 5)
            {
                Contacts.Add(new Contact()
                {
                    FirstName = DataPool.GenerateFirstName(rnd),
                    LastName = DataPool.GenerateLastName(rnd),
                    State = DataPool.GenerateState(rnd)
                });
    
                i++;
            }
        }
    
        private async void SimulateLiveChanges(TimeSpan MyInterval)
        {
            double MyIntervalSeconds = MyInterval.TotalSeconds;
            while (true)
            {
                await Task.Delay(MyInterval);
    
                //int addOrRemove = rnd.Next(1, 10);
                //if (addOrRemove > 3)
                //{
                // add item
                Contacts.Add(new Contact()
                {
                    FirstName = DataPool.GenerateFirstName(rnd),
                    LastName = DataPool.GenerateLastName(rnd),
                    State = DataPool.GenerateState(rnd)
                });
                //}
                //else
                //{
                //    // remove random item
                //    if (Contacts.Count > 0)
                //    {
                //        Contacts.RemoveAt(rnd.Next(0, Contacts.Count - 1));
                //    }
                //}
            }
        }
    
    }
    
    // ViewModel
    
    public class ViewModel : BaseViewModel
    {       
        public ViewModel()
        {
            _groupingCollection = new ObservableGroupingCollection<string, Contact>(new Cache().Contacts);
            _groupingCollection.ArrangeItems(new StateSorter(), (x => x.State));
            NotifyPropertyChanged("GroupedContacts");
    
        }
    
        ObservableGroupingCollection<string, Contact> _groupingCollection;
        public ObservableCollection<Grouping<string, Contact>> GroupedContacts
        {
            get
            {
                return _groupingCollection.Items;
            }
        }
    
        // swap grouping commands
    
        private ICommand _groupByStateCommand;
        public ICommand GroupByStateCommand
        {
            get
            {
                if (_groupByStateCommand == null)
                {
                    _groupByStateCommand = new RelayCommand(
                        param => GroupByState(),
                        param => true);
                }
                return _groupByStateCommand;
            }
        }
        private void GroupByState()
        {
            _groupingCollection.ArrangeItems(new StateSorter(), (x => x.State));
            NotifyPropertyChanged("GroupedContacts");
        }
    
        private ICommand _groupByNameCommand;
        public ICommand GroupByNameCommand
        {
            get
            {
                if (_groupByNameCommand == null)
                {
                    _groupByNameCommand = new RelayCommand(
                        param => GroupByName(),
                        param => true);
                }
                return _groupByNameCommand;
            }
        }
        private void GroupByName()
        {
            _groupingCollection.ArrangeItems(new NameSorter(), (x => x.LastName.First().ToString()));
            NotifyPropertyChanged("GroupedContacts");
        }
    
    }
    
    // View Model helpers
    
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
    
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
    
        }
    
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
    
            _execute = execute;
            _canExecute = canExecute;
    
        }
    
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
    
        public event EventHandler CanExecuteChanged
        {
            add { } 
            remove { } 
        }
    
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    
    }
    
    // Sorter classes
    
    public class NameSorter : Comparer<Contact>
    {
        public override int Compare(Contact x, Contact y)
        {
            int result = x.LastName.First().CompareTo(y.LastName.First());
    
            if (result != 0)
            {
                return result;
            }
            else
            {
                result = x.LastName.CompareTo(y.LastName);
    
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return x.FirstName.CompareTo(y.FirstName);
                }
            }
        }
    }
    
    public class StateSorter : Comparer<Contact>
    {
        public override int Compare(Contact x, Contact y)
        {
            int result = x.State.CompareTo(y.State);
    
            if (result != 0)
            {
                return result;
            }
            else
            {
                result = x.LastName.CompareTo(y.LastName);
    
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return x.FirstName.CompareTo(y.FirstName);
                }
            }
        }
    }
    // Grouping class 
    // credit
    // http://motzcod.es/post/94643411707/enhancing-xamarinforms-listview-with-grouping
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }
        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }
    }
