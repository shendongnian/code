    public void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {        
        if (!ValidNumericString(textBox1.Text))
        {
            MessageBox.Show("You have entered invalid characters! Please enter a number");
            Dispatcher.BeginInvoke(new Action(() => textBox1.Undo()));
            e.Handled = true;
        }
    }
    public bool ValidNumericString(string IPString)
    {
        return IPString.All(char.IsDigit);
        // OR make this check for thousands & decimals if required
    }
