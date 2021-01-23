    public partial class Parent : Form
        {
            private Child childForm;
    
            public Parent()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Open the child form
                childForm = new Child();
                childForm.DatabaseChanged += childForm_DatabaseChanged;
                childForm.ShowDialog();
            }
    
            void childForm_DatabaseChanged(string newDatabaseName)
            {
                // This will get called everytime you call "DatabaseChanged" on child
                label1.Text = newDatabaseName;
            }
        }
