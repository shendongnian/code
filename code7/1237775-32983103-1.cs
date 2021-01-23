    public partial class Form1 : Form
    {
        // number of guesses
        int numberOfGesses = 0;
    	 int number;
    
        public Form1()
        {
            InitializeComponent();
    		
            // Generate the random number
            Random generator = new Random();
            number = generator.Next(1, 10);
        }
        
        private void btnCalc_Click(object sender, EventArgs e)
        {
            // get the users guess
            int guess = int.Parse(txtInput.Text);
    
            //check the users guess
            if (guess == number)
            {
                lblAnswer.Text = "You got it";
                numberOfGesses = 0;
            }
            else if (guess != number)
            {
                numberOfGesses = numberOfGesses + 1;
                lblAnswer.Text = "try agian you have gessed" + (numberOfGesses) + " times";
            }
        }
    }
