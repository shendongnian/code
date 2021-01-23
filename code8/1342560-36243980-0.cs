    class Model : INotifyPropertyChanged
    {
        private static readonly Random _random = new Random();
        private const int _kcolumnCount = 6;
        private const int _krowCount = 4;
        private string _word;
        public ObservableCollection<char> Letters { get; private set; }
        public string Word
        {
            get { return _word; }
            set { _UpdateValue(ref _word, value); }
        }
        public int ColumnCount { get { return _kcolumnCount; } }
        public int RowCount { get { return _krowCount; } }
        public Model()
        {
            Letters = new ObservableCollection<char>();
            for (int i = 0; i < ColumnCount * RowCount; i++)
            {
                Letters.Add(' ');
            }
        }
        public void UpdateLetters()
        {
            char[] characters = new char[ColumnCount * RowCount];
            for (int i = 0; i < characters.Length; i++)
            {
                if (Word != null && i < Word.Length)
                {
                    characters[i] = Word[i];
                }
                else
                {
                    characters[i] = (char)('a' + _random.Next(26));
                }
            }
            for (int i = characters.Length - 1; i > 0 ; i--)
            {
                int j = _random.Next(i + 1);
                if (i != j)
                {
                    char chT = characters[i];
                    characters[i] = characters[j];
                    characters[j] = chT;
                }
            }
            for (int i = 0; i < characters.Length; i++)
            {
                Letters[i] = characters[i];
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _UpdateValue<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, newValue))
            {
                field = newValue;
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
