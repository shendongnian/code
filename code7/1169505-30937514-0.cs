    if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]"))
    {
        MessageBox.Show("This textbox accepts only alphabetical characters");
        textBox1.Text.Remove(textBox1.Text.Length - 1);
    }
