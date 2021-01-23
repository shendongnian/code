    namespace WindowsFormsApplication2
    {
      public partial class Form1 : Form
      {
    
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            test.Text = (string)Settings.Default["lastCustomers"];
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default["lastCustomers"] = test.Text;
            Settings.Default.Save();
        }
      }
    }
