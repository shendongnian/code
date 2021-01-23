    namespace IntegerGame
    {
    public partial class guessGame : Form
    {
        int num1;
        int num2;
        Random rnd1 = new Random();
    
        public guessGame()
        {
            InitializeComponent();
            num1 = rnd1.Next(1, 10);
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
        }
    
        private void guessButton_Click(object sender, EventArgs e)
        {
    
            if (int.TryParse(textBox1.Text, out num2))
            {
    
    
                    if (num2 < 0 || num2 > 10)
                    {
                        textBox1.Clear();
                        MessageBox.Show("Please enter a number between 1 and 10");
                    }
    
                    else
                    {
                        if (num2 > num1)
                        {
                            textBox1.Clear();
                            MessageBox.Show("You guessed to high, please try again");
                        }
    
                        else if (num2 < num1)
                        {
                            textBox1.Clear();
                            MessageBox.Show("You guessed to low, please try again");
                        }
                        // Note that this could be an else: it is the only case left
                        else if (num2 == num1)
                        {
                            num1 = rnd1.Next(1, 10);
                            textBox1.Clear();
                            MessageBox.Show("You guessed " + num2 + ", which was the right number!!");
                        }
                    }
    
            }
    
            else
            {
                textBox1.Clear();
                MessageBox.Show("This is not a valid integer, please enter a valid integer");
           
