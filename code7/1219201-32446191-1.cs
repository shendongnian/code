    if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[0-9,]*$"))
    {
        MessageBox.Show("Please enter only numbers and commas.");
    }
    
