    namespace TreeViewExample
    {
       public class MyNode
       {
        public ObservableCollection<MyNode> ChildNodes { get; set; }
        public int Number { get; set; }
        public MyNode()
        {
            ChildNodes = new ObservableCollection<MyNode>();
        }
       }
    public class SimpleCommand : ICommand
    {
        private readonly Action _action;
        public SimpleCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (parameter is string && (string) parameter == "async")
            {
                new TaskFactory().StartNew(_action);
            }
            else _action();
        }
        public event EventHandler CanExecuteChanged;
    }
    public class NodeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MyNode> _rootNodes;
        public ObservableCollection<MyNode> RootNodes
        {
            set
            {
                _rootNodes = value;
                OnPropertyChanged();
            }
            get { return _rootNodes; }
        }
        private readonly ICommand _populateCommand;
        private readonly Random _random;
        private Dispatcher _dispatcher;
        public ICommand PopulateCommand { get { return _populateCommand; } }
        public NodeViewModel()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            _random = new Random();
            _populateCommand = new SimpleCommand(PopulateTree);
            RootNodes = new ObservableCollection<MyNode>();
        }
        private void PopulateTree()
        {
            try
            {
                var node = new MyNode {Number = 0};
                if (_dispatcher.CheckAccess())
                    RootNodes.Add(node);
                else _dispatcher.Invoke(() => RootNodes.Add(node));
                FillNodeRecursively(node, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void FillNodeRecursively(MyNode rootNode, int level)
        {
            int rand = _random.Next(0, 4);
            for (var i = 0; i <= rand; i++)
            {
                var subNode = new MyNode {Number = rand + i};
                Thread.Sleep(50); //simulating some workload
                if (_dispatcher.CheckAccess())
                    rootNode.ChildNodes.Add(subNode);
                else _dispatcher.Invoke(() => rootNode.ChildNodes.Add(subNode));
                if (level < 4)
                    FillNodeRecursively(subNode, level + 1);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
