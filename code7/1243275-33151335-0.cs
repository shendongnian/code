    public class Form1:Form
    {
        public YourForm()
        {
            InitiallizeComponent();
        }
    
        private OdbcConnection connection;
        publlic OdbcConnection Connection
        {
            get
            {
                if(connection == null)
                    connection= new OdbcConnection("your connection string here");
                return connection;
            }
        }
        //If you want to open and close connection automatically uncomment this codes
        //Then you don't need to open and close connection manually
        //protected override void OnLoad(EventArgs e)
        //{
        //    this.Connection.Open();
        //    base.OnLoad();
        //}
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    this.Connection.Close();
        //    this.Connection.Dispose();         
        //    base.OnClosing(e);
        //}
    }
