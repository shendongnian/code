    if (string.IsNullOrEmpty(txtP2.Text) || string.IsNullOrWhiteSpace(txtP2.Text)
       || string.IsNullOrEmpty(txtQ2.Text) || string.IsNullOrWhiteSpace(txtQ2.Text)
       || string.IsNullOrEmpty(txtR2.Text) || string.IsNullOrWhiteSpace(txtR2.Text))
    {
    	// ...
    }
    else if ((!string.IsNullOrEmpty(txtP2.Text) || !string.IsNullOrWhiteSpace(txtP2.Text)) && Decimal.TryParse(txtA2.Text, out amt2))
    {
        // ...
    }
