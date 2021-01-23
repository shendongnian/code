    private void OnCCTVButtonClick(object sender, RoutedEventArgs e)
    {
        var selectedItem = ((ListBoxItem)imageListBox.ContainerFromElement((Button)sender)).Content as CCTVImage;
        if (selectedItem != null)
        {
            Process.Start("chrome.exe", selectedItem.CCTVPath);
        }
    }
