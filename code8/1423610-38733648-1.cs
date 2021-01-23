    private async void button_Click(object sender, RoutedEventArgs e)
    {
        if (go)
        {
            city = textBox.GetLineText(0);
            if (city == "exit")
            {
                Environment.Exit(0);
            }
    
            await Task.Run(() => start());
        }
    }
