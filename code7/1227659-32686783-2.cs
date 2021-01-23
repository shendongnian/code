    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();           
        }
        
        GuessingGame myGuess = new GuessingGame(); 
        private void btnCheck_Click(object sender, EventArgs e)
        {      
            // I suggest to add here textbox text validation
            // so user couldn't input anything apart number.
            int inputGuess = Convert.ToInt32(txtGuess.Text);     
            myGuess.checkGuess(inputGuess);
        }
    }
