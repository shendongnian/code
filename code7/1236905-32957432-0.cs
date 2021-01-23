    public partial class Form1 : Form 
    { 
        private int Yes_Tally = 0;
        private int No_Tally = 0;
        public Form1() 
        { 
            InitializeComponent(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTally();
        }
        private void Eyes1_Click(object sender, EventArgs e)
        {
            Yes_Tally++;
            UpdateTally();
        }
        private void Eyes2_Click(object sender, EventArgs e)
        {
            No_Tally++;
            UpdateTally();
        }
        private void UpdateTally()
        {
            lblTally.Text = String.Format("Yes: {0}, No: {1}", Yes_Tally, No_Tally);
        }
    }
