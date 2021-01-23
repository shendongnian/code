    class MyViewModel
    {
        public List<MyItem> MyItems { get; set; }
        public int Width { get; set; }
        public MyItem FirstElement { get { return MyItems[0]; } }
    }
