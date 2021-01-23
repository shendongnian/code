        public partial class Service1 : ServiceBase
        {
            private Thread _thread;
    
            public Service1()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                _thread = new Thread(DoWork);
                _thread.Start();
            }
    
            private void DoWork()
            {
                // Write your code here...
                File.WriteAllText(@"C:\Test123.txt","hello world!");
            }
    
            protected override void OnStop()
            {
            }
        }
