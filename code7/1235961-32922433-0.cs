    private void button1_Click(object sender, EventArgs e)
    {
        bool guess;
        int.TryParse(textBox_Guess.Text, out guess);
        if(!guess){
            label_Reveal.ForeColor = System.Drawing.Color.Red;
            label_Reveal.Text = "Your input is invalid!";
            label_Reveal.Show();
        }
    }
