    public class Main4ViewModel : MvxViewModel
    {
        public ObservableCollection<MySource> Source { get; private set; }
        public MvxCommand<MySource> BCommand { get; private set; }
        public Main4ViewModel()
        {
            Source = new ObservableCollection<MySource>()
            {
                new MySource("e1", "b1"),
                new MySource("e2", "b2"),
                new MySource("e3", "b3"),
            };
            BCommand = new MvxCommand<MySource>(ExecuteBCommand);
        }
        private void ExecuteBCommand(MySource source)
        {
            Debug.WriteLine("ExecuteBCommand. Source: A={0}, B={1}", source.A, source.B);
        }
    }
