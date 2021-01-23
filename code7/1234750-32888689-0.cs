    // Empty or wrong format
    if (string.IsNullOrWhiteSpace(textBox1.Text))
    {
        label5.Text = "You didn't enter anything!";
    }
    else
    {
        bool onlyLetters = textBox1.Text.All(x => Char.IsLetter(x));
        if (!onlyLetters)
        {
            label5.Text = "Your name is incorrect!";
        }
        else
        {
            label5.Text = "";
        }
    }
