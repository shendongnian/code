    namespace DoubleForms
    {
        public partial class Form2 : Form
        {
            public event EventHandler Updated;  // define an event handler
            
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                 if(Updated != null)
                 {
                      Updated(sender, new EventArgs()); //Raise a change.
                 }
            }
        }
    }
    
