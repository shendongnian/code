    using System.Threading.Tasks;
    ...
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = (UIElement)sender;
        button.IsEnabled = false;
        await Task.Run(() => DoTheBootstrapping());
        button.IsEnabled = true;
    }
