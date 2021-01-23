    namespace IntegerGame
    {
    public partial class guessGame : Form
    {
        int num1;
        int num2;
    public guessGame()
    {
        Random rnd1 = new Random();
        num1 = rnd1.Next(1, 10);
        InitializeComponent();
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
                    else if (num2 == num1)
                    {
                        textBox1.Clear();
                        MessageBox.Show("You guessed " + num2 + ", which was the right number!!");
                    }
                }
        }
        else
        {
            textBox1.Clear();
            MessageBox.Show("This is not a valid integer, please enter a valid integer");
        }
    }
  }
}
