    double parsedValue;
  
    if (!double.TryParse(textBox.Text, out parsedValue))
    {
        MessageBox.Show("This is a double only field");
        return;
    }
