    public class MyViewModel
    {
        public ObservableCollection<MyData> Data { get; set; }
        public MyViewModel()
        {
            Data = new ObservableCollection<MyData>
            {
                new MyData {Name="Country 1", Count = 10 },
                new MyData {Name="Country 2", Count = 25 },
                new MyData {Name="Country 3", Count = 40 },
            };
        }
    }
