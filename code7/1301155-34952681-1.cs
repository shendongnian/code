    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ItemViewModel _currentObject = new ItemViewModel() { Value = TestEnum.Test3 | TestEnum.Test7 };
        public ItemViewModel CurrentObject
        {
            get { return _currentObject; }
            set
            {
                _currentObject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentObject)));
            }
        }
    }
    public class ItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TestEnum _value;
        public TestEnum Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelValue)));
            }
        }
        public string SelValue
        {
            get
            {
                return String.Join(",", Enum.GetValues(typeof(TestEnum)).OfType<TestEnum>().Where(v => (_value & v) != 0).Select(v => v.ToString()));
            }
            set
            {
                _value = value.Split(new[] { ','}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()). 
                    Aggregate((TestEnum)0, (acc, val) => acc | (TestEnum)Enum.Parse(typeof(TestEnum), val));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelValue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        public ObservableCollection<string> Items
        {
            get
            {
                return new ObservableCollection<string>(Enum.GetNames(typeof(TestEnum)));
            }
        }
    }
