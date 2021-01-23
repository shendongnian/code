    public class MyDesignViewModel : ViewModelBase
    {
        public MyViewModel()
        {
            Data = new ObservableCollection<IData>(new List<IData>() 
            {
                 new MyData() { Value1 = 1, Value2 = "Test" },
                 ...
            });
        }
        public ObservableCollection<IData> Data { get; private set; }
    }
