    public class MyViewModel
    {
        public ObservableCollection<MyDataModelClass> Data { get; set; }
        public MyViewModel()
        {
            Data = new ObservableCollection<MyDataModelClass>
            {
                new MyDataModelClass {X = 1, Y = 10, Info = "Info 1" },
                new MyDataModelClass {X = 2, Y = 40, Info = "Info 2" },
                new MyDataModelClass {X = 3, Y = 20, Info = "Info 3" },
                new MyDataModelClass {X = 4, Y = 50, Info = "Info 4" },
                new MyDataModelClass {X = 5, Y = 30, Info = "Info 5" },
            };
        }
    }
