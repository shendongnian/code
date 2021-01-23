    public class MainViewModel : MvxViewModel
    {
        public ObservableCollection<Mysource> Source { get; private set; }
        public MainViewModel()
        {
            Source = new ObservableCollection<Mysource>()
            {
                new Mysource("e1", "b1"),
                new Mysource("e2", "b2"),
                new Mysource("e3", "b3"),
            };
        }
    }
