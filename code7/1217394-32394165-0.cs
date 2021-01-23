    class Form1
    {
        public static Form1 Instance {get; private set;}
        public Form1()
        {
            Instance = this;
            //InitializeComponents and what ever else.
        }
        public void LoadTable()
        {
            //implementation
        }
    }
