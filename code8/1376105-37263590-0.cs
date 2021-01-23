    namespace Image
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                // set picture box to image of interest
                // size and position form appropriately
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }
    }
