    public class MainViewModel : MvxViewModel
    {
        public ObservableCollection<MySource> Source { get; private set; }
        public MainViewModel()
        {
            Source = new ObservableCollection<MySource>()
            {
                new MySource("e1", "b1"),
                new MySource("e2", "b2"),
                new MySource("e3", "b3"),
            };
        }
    }
