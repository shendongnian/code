    private async void ButtonWithCodeBehindOnClick(object sender, RoutedEventArgs e)
    {
        ButtonWithCodeBehind.Content = "First";
        await Task.Factory.StartNew(() => Thread.Sleep());
        ButtonWithCodeBehind.Content = "Second";
        await Task.Factory.StartNew(() => Thread.Sleep());
        ButtonWithCodeBehind.Content = "Third";
    }
