    public class MyElementViewModel : MvxViewModel
    {
        public Mysource Source { get; private set; }
        public MvxCommand BCommand { get; private set; }
        public MyElementViewModel(Mysource source)
        {
            Source = source;
            BCommand = new MvxCommand(ExecuteBCommand);
        }
        private void ExecuteBCommand()
        {
            Debug.WriteLine("ExecuteBCommand. Source: A={0}, B={1}", Source.A, Source.B);
        }
    }
