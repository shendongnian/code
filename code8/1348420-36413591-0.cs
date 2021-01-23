    private async void button_Click(object sender, RoutedEventArgs e)
    {
        TaskFactory taskFactory = new TaskFactory();
        var x = taskFactory.StartNew(() => reader.Read());
        await x;
    }
