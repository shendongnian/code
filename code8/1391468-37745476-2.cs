    private async void ShowDialog_Click(object sender, RoutedEventArgs e)
    {
        // Show the custom dialog
        MyCustomContentDialog dialog = new MyCustomContentDialog();
        await dialog.ShowAsync();
        // Use the returned custom result
        if (dialog.Result == MyResult.Yes)
        {
            DialogResult.Text = "Dialog result Yes.";
        }
        else if (dialog.Result == MyResult.Cancle)
        {
            DialogResult.Text = "Dialog result Canceled.";
        }
        else if (dialog.Result == MyResult.No)
        {
            DialogResult.Text = "Dialog result NO.";
        }
    }
