    if(!int.TryParse(textBox_Guess.Text, out guess))
    {
       label_Reveal.ForeColor = System.Drawing.Color.Red;
       label_Reveal.Text = "Your input is invalid!";    
       label_Reveal.Visible = true;
    }
