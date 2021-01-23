    if (string.IsNullOrWhiteSpace(AgeInput.Text))
    {
    	Textblock1.Text = "✘";
    }
    else if(Char.IsNumber(AgeInput.Text.All))
    {
    	Textblock1.Text = "✔";
    }
