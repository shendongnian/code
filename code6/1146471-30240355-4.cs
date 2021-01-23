    //codebehind
    //HeadersVM is my ViewModel  
    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
                HeadersVM.SelectedHeaders.Add((Models.MailHeader)item);
            foreach (var item in e.RemovedItems)
                HeadersVM.SelectedHeaders.Remove((Models.MailHeader)item);
        }
    private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.HeadersVM.GoBack();
        }
