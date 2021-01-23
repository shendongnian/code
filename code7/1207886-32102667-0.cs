    public YourFormConstructor()
    {
    	foreach(var textbox in form.Controls.OfType<TextBox>())
		    textbox.Leave += FormatCurrencyText;
    }
    
    
    private void FormatCurrencyText(object sender, EventArgs e)
    {
    	var textbox = sender as TextBox;
    	Double value;
    	if (Double.TryParse(textbox.Text, out value))
    		textbox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
    	else
    		textbox.Text = String.Empty;
    }
