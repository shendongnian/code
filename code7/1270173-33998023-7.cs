    class Class1 : BindableObject
    {
        private string _val;
        public string val
        {
            get { return _val; }
            set { SetProperty(ref _val, value); }
        }
    }
