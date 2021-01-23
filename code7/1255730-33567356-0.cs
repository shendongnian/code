    public class MyViewModel : BindableBase
    {
        private IWorker;
        public MyViewModel(IWorker worker = null)
        {
            if (worker == null)
            {
                _worker = new Worker();
            }
            this.PropertyChanged += MyViewModel_PropertyChanged;
        }
    
        private void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DataHolder data = new DataHolder();
            Action action = async () => await DoSomething(data);
            action();
        }
    
        public string Status { get; private set; } = DataHolder.BeforeKey;
    
    
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
