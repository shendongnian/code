    public class Form1:Form
    {
        public YourForm()
        {
            InitiallizeComponent();
        }
    
        private OdbcConnection connection;
        //If you want to open and close connection automatically uncomment commented codes
        //Then you don't need to open and close connection manually
        protected override void OnLoad(EventArgs e)
        {
            connection= new OdbcConnection("your connection string here");
            //this.Connection.Open();
            base.OnLoad();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            //this.Connection.Close();
            this.Connection.Dispose();         
            base.OnClosing(e);
        }
    }
