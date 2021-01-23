    namespace Machine_Name
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            // This is the form load event handler
            private void Form1_Load(object sender, EventArgs e)
            {
                yourLabel.Text = Environment.MachineName;
            }
        }
    }
