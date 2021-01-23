    public class MyModel
    {
        public string MyValue { get; set; }
        ...
    }
    public class MyViewModel
    {
        private MyModel _Model;
        public string MyModelValue
        {
            get { return _Model.MyValue; }
            set 
            {
                _Model.MyValue = value;
                //Notify property changed.
            }
        }
        ...
    }
