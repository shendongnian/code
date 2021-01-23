    private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string inputString = ((TextBox)sender).Text;
        char lastChar = inputString.Last();
        Console.WriteLine(lastChar);
    }
