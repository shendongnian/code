    public void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {        
        if (!textBox1.Text.All(char.IsDigit))
        {
            MessageBox.Show("You have entered a symbol! Please enter a number");
            e.Handled = true;
        }
    }
