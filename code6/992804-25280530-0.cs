    public class MyViewModel
    {
        private MyClass _data;
        public MyClass DatatoLoad
        {
            get { return _data; }
            set { _data = value; }
        }
    }
    ...
    if (e.Result != null)
    {
        this.DataContext = new MyViewModel { DatatoLoad = e.Result };
    }
    
