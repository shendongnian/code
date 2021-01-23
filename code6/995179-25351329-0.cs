    private double CheckTextBox(TextBox textBox)
    {
        Double value;
        if (Double.TryParse(textBox.Text, out value))
    	{
            return value;
        } 
    	else 
    	{
            logbox.AppendText(string.Format("Box {0} does not contain a double", textBox.Name));
            textBox.Text = ("NO DOUBLE FOUND");
            value = double.NaN;
            return value;
        }
    }
