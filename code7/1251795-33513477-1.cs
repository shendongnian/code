    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            textbox.Text = "Awaiting SecondTask result";
            int x = await SecondTask();
            window.Title = "SecondTask completed with " + x.ToString();
            await ThirdTask();
        }
        catch (ArgumentException ex)
        {
            textbox.Text = ex.Message;
        }
    }
