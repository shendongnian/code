    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var t = new TextBlock();
        t.Text = "TEXT1";
        var t2 = new TextBlock();
        t2.Text = "TEXT2";
        dummyStack.Children.Add(t);
        await Task.Delay(100);
        // This can be any synchronous work 
        Thread.Sleep(5000);
        dummyStack.Children.Add(t2);
    }
