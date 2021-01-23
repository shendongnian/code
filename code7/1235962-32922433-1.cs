    private void button1_Click(object sender, EventArgs e)
    {
        int num;
        bool guessCorrect = int.TryParse(textBox_Guess.Text, out num);
        if(!guessCorrect){
            label_Reveal.ForeColor = System.Drawing.Color.Red;
            label_Reveal.Text = "Your input is invalid!";
            label_Reveal.Show();
        }
    }
