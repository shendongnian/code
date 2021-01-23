    private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            WritePadFileContent listitem = (e.OriginalSource as MenuFlyoutItem).DataContext as WritePadFileContent;
            MessageDialog messageDialog = new MessageDialog(listitem.Name.ToString());
            await messageDialog.ShowAsync();
    
    
    
            //code for export to pdf, it works
        }
