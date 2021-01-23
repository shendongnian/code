	public partial class frmGuess : Form
	{
		public frmGuess()
		{
			InitializeComponent();
		}
		private void frmGuess_Load(object sender, EventArgs e)
		{
			lblCount.Visible = true;
			lblHowMuch.Visible = true;
			ResetData();
		}
		
		private void btnReset_Click(object sender, EventArgs e)
		{
			ResetData();
		}
		
		private Random r = new Random();
		private int guessCount;
		private int target;
		
		private void ResetData()
		{
			guessCount = 0;
			target = r.Next(0, 101);
			txtGuess.Text = "";
			lblCount.Text = "";
			lblHowMuch.Text = "";
			this.BackColor = System.Drawing.Color.Empty;
			txtGuess.Focus();
		}
		private void btnCheck_Click(object sender, EventArgs e)
		{
			int userGuess = int.Parse(txtGuess.Text);
			guessCount++;
			
			if (userGuess == target)
			{
				this.BackColor = System.Drawing.Color.DarkOliveGreen;
				lblHowMuch.Text = String.Format(
					"You guessed the right number it took you {0} guesses",
					guessCount);
			}
			else
			{
				this.BackColor = userGuess < target
					? System.Drawing.Color.Yellow
					: System.Drawing.Color.Red;
			}
			
			lblCount.Text = String.Format(
				"You made {0} Guesses",
				guessCount);
		}
	}
