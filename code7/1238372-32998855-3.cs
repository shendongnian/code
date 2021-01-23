    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Answer = random.Next(0, 99);
            User_Guess = 0;
            Guess_num = 0;
        }
        Random random = new Random();
        int Answer;
        int User_Guess;
        int Guess_num;
        private void Guess_btn_Click(object sender, EventArgs e)
        {
            try
            {
                User_Guess = int.Parse(Guess_txtbx.Text);
                Guess_num++;
                if (User_Guess == Answer)
                {
                    MessageBox.Show("Your answer is correct! It took you " + Guess_num + "number of guesses.");
                    Guess_num = 0;
                    return;
                }
                MessageBox.Show(String.Format("Your answer is too {0}, try again.", User_Guess > Answer ? "High" : "Low"));
                Guess_txtbx.Clear();
                Guess_txtbx.Focus();
             }
            
            catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
             }
        }
    }
