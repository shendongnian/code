    public MyForm: Form
    {
        private static MyForm _instance;
        public static MyForm Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new MyForm();
                return instance;
            }
        }
    }
