    public partial class Child : Form
        {
            public event DatabaseChangeHandler DatabaseChanged;
            public delegate void DatabaseChangeHandler(string newDatabaseName);
    
            public Child()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //When the database changes
                if (this.DatabaseChanged != null)
                {
                    this.DatabaseChanged("The New Name");
                }
            }
        }
