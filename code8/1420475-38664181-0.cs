    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        while (true)
        {
            string result = await LoadNextItem();
            lbl1.Content = result;
        }
    }
    private static int ir11 = 0;
    Task<string> LoadNextItem()
    {
        await Task.Delay(1000); // placeholder for actual async work
        ir11++;
        return "aa " + ir11;
    }
