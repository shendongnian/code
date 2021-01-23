    public class MainViewModel : MvxViewModel
    {
        public ObservableCollection<Mysource> Source { get; private set; }
        public MvxCommand<Mysource> BCommand { get; private set; }
        public MainViewModel()
        {
            Source = new ObservableCollection<Mysource>()
            {
                new Mysource("e1", "b1"),
                new Mysource("e2", "b2"),
                new Mysource("e3", "b3"),
            };
            BCommand = new MvxCommand<Mysource>(ExecuteBCommand);
        }
        private void ExecuteBCommand(Mysource source)
        {
            Debug.WriteLine("ExecuteBCommand. Source: A={0}, B={1}", source.A, source.B);
        }
    }
