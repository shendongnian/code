    public class MyViewModel : BindableBase
    {
        private IWorker _worker;
        private readonly DataHolder _data = new DataHolder(){Test = DataHolder.BeforeKey};
        public string Status { get { return _data.Status; } }
        public MyViewModel(IWorker worker = null)
        {
            _worker = worker;
            if (_worker == null)
            {
                _worker = new Worker();
            }
            this.PropertyChanged += MyViewModel_PropertyChanged;
        }
    
        private void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Action action = async () => await _worker.DoSomething(_data);
            action();
        }
    
    
        string bindagleProp;
        public string BindagleProp
        {
            get { return bindagleProp; }
            set { SetProperty(ref bindagleProp, value); }
        }
    }
    public class DataHolder
    {
        public const string BeforeKey = "before";
        public const string AfterKey = "After";
        public string Status;
    }
    public interface IWorker
    {
        Task DoSomething(DataHolder data);
    }
    public class Worker : IWorker
    {
        public async Task DoSomething(DataHolder data)
        {
            await Task.Delay(3000);
            data.Status = DataHolder.AfterKey;
        }
    }
