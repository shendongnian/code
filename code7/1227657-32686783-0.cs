     public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();           
        }
        int inputGuess = 0;
        GuessingGame myGuess; 
        private void btnCheck_Click(object sender, EventArgs e)
        {           
            myGuess = new GuessingGame(inputGuess);
            myGuess.checkGuess();
            inputGuess = Convert.ToInt32(txtGuess.Text)
        }
    }
