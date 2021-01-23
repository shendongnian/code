        public delegate void MyEventHadler();
        public event MyEventHadler Initialize;
        public  void InitializeFunction()
        {
            if (Initialize != null)
                Initialize.Invoke();
        }
