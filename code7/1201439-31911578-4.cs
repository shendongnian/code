    //Set Access Modifier of that button to public or internal for same namespace
    namespace Secretary_1._0
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public void StartClient()
            {
                var client = new Client(this);
                client.RequiredMethod();  //Call here method of client
            }
        }
    }
