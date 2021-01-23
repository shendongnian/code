    class MyViewModel
    {
        private ObservableCollection<MyObject> _myObjects;
        public ObservableCollection<MyObject> MyObjects
        {
            get { return _myObjects; }
            set { _myObjects = value; }
        }
        public MyViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                var obj = new MyObject();
            }
        }
    }
