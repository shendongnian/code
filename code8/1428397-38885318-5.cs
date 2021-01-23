    public class MyViewModel
    {
        public ObservableCollection<MyData> Data { get; set; }
        public MyViewModel()
        {
            Data = new ObservableCollection<MyData>
            {
                new MyData {ID = 1, Name = "Name 1" },
                new MyData {ID = 2, Name = "Name 2" },
                new MyData {ID = 3, Name = "Name 3" },
                new MyData {ID = 4, Name = "Name 4" },
                new MyData {ID = 5, Name = "Name 5" },
            };
        }
    }
