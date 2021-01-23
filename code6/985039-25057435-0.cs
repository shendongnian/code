    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Activated += Form2_Activated;
            label1.Text = "Initialised";
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            // Call methods to do work from here, for example:
    
            label1.Text = "Working ...";
            Refresh();
            System.Threading.Thread.Sleep(500);
            label1.Text = "Still Working ...";
            Refresh();
            System.Threading.Thread.Sleep(500);
            label1.Text = "Done!";
            Refresh();
            System.Threading.Thread.Sleep(500);
            this.Close();
        }
    }
