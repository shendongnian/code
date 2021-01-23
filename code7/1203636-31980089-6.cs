    public enum SquareValue
    {
        Empty = 0,
        X = 1,
        O = 2
    }
    public class Square: INotifyPropertyChanged
    {
        private SquareValue _value;
        public SquareValue Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Game
    {
        public List<Square> Squares { get; private set; }
        public Game()
        {
            this.Squares = 
                Enumerable.Range(0, 9)
                          .Select(x => new Square { Value = SquareValue.Empty })
                          .ToList();
        }
    }
