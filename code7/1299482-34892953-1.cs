    public class MyModel
    {
        public MyModel()
        {
            myObject = new ObservableCollection<MyObject>
            {
                new MyObject { name = "John", number = 5 },
                new MyObject { name = "Jane", number = 6 },
                new MyObject { name = "Sam", number = 9 },
                new MyObject { name = "Lara", number = 16 }
            };
        }
    
        public ObservableCollection<MyObject> myObject { get; set; }
    }
    
    public class MyObject
    {
        public int number { get; set; }
        public string name { get; set; }
    }
