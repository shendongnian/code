    public partial class Form1 : Form
    {
        const double CONTRACT_BALANCE = 229481.65;
        const double SUB_BALANCE = 196817.63;
        double subBal = SUB_BALANCE;
        double bal = CONTRACT_BALANCE;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        void Form1_Load(object sender, EventArgs e)
        {
            subBalLabel.Text = subBal.ToString("C");
            balanceLabel.Text = bal.ToString("C");
        }
        private void button1_Click(object sender, EventArgs e)
        {  
            double enterPayment = 0;
            subBalLabel.Text = subBal.ToString("C");
            balanceLabel.Text = bal.ToString("C");
            //User Input Payment
            enterPayment = Double.Parse(payCOTextBox.Text);
            // balances
            subBal = subBal + enterPayment;
            bal = bal + enterPayment;
            // Text Labels
            subBalLabel.Text = subBal.ToString("C");
            balanceLabel.Text = bal.ToString("C");
             // Clear Text Box
            payCOTextBox.Clear();
        }
    }
