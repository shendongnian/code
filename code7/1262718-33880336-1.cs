    public class MyDataCollection : List<MyData>
    {
        public MyDataCollection()
        {
            Add(new MyData { MyItem = "Item 5", MyDate = new DateTime[] { new DateTime(2015, 8, 1), new DateTime(2015, 11, 1) } });
            Add(new MyData { MyItem = "Item 4", MyDate = new DateTime[] { new DateTime(2015, 6, 1), new DateTime(2015, 11, 1) } });
            Add(new MyData { MyItem = "Item 3", MyDate = new DateTime[] { new DateTime(2015, 9, 1), new DateTime(2015, 11, 1) } });
            Add(new MyData { MyItem = "Item 2", MyDate = new DateTime[] { new DateTime(2015, 10, 1), new DateTime(2015, 11, 1) } });
            Add(new MyData { MyItem = "Item 1", MyDate = new DateTime[] { new DateTime(2015, 7, 1), new DateTime(2015, 11, 1) } });
        }
    }
    public class MyData
    {
        public string MyItem { get; set; }
        public DateTime[] MyDate { get; set; }
    }
