    public class Foo : INotifyPropertyChanged, IF1
    {
        public Foo(string name)
        {
            _name = name;
        }
        private string _name;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        string IF1.Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
    }
    public interface IF1
    {
        string Name { set; get; }
    }
