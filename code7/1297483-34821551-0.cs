    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Firstnames = new List<string>();
            Firstnames.Add("James");
            Firstnames.Add("Jakob");
            Firstnames.Add("Jacob");
            Firstnames.Add("Jonathan");
            Firstnames.Add("Albert");
            Firstnames.Add("Calvin");
            Firstnames.Add("Kyle");
            Firstnames.Add("Christopher");
            Firstnames.Add("Jeremy");
            Firstnames.Add("Ari");
            Firstnames.Add("Maximus");
            Firstnames.Add("Jerry");
            Firstnames.Add("Eric");
            Firstnames.Add("Trey");
            Firstnames.Add("Brenden");
            Firstnames.Add("Sean");
            Firstnames.Add("Timmothy");
            Firstnames.Add("Harris");
            Firstnames.Add("Matthew");
            Firstnames.Add("Michael");
            Firstnames.Add("Ching");
            Firstnames.Add("Alexander");
    
            Form2 f = new Form2(Firstnames);
    
            try
            {
                f.ShowDialog();
            }
            finally
            {
                f.Dispose();
            }
        }
    
    }
