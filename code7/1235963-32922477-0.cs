    var guessString = textBox_Guess.Text;
    int guessParsed;
    var success = int.TryParse(guessString, out guessParsed);
    if(!success) {
        label_Reveal.ForeColor = System.Drawing.Color.Red;
        label_Reveal.Text = "Your input is invalid!";
        label_Reveal.Show();
    }
