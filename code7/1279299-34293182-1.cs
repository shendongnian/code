    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        // Prevent entering again before this function is finished:
        Button clickedButton = (Button)sender;
        clickedButton.Enabled = false;
        // process the clicked button:
        Task<int> i = LongTaskAsync();    // first break point here
        int k = await i;
        print("Done, i=" + i);
        // Finished processing, enable the button again:
        clickedButton.Enabled = true;
    }
