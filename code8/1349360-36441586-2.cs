    private Book deleteAccessBook;
    private void RightTapHold(object sender, RightTappedRoutedEventArgs e)
    { 
        var holdedElement = e.OriginalSource as FrameworkElement;
        if (holdedElement == null) return;
        deleteAccessBook = holdedElement.DataContext as Book;
        SharedMenu.ShowAt(holdedElement);
    }
    private async void DeleteShared_Tapped(object sender, RoutedEventArgs e)
    {
        if (deleteAccessBook == null) return;
        bookAccessCollection = await BookAccessTable.ToCollectionAsync();
        foreach (var item in bookAccessCollection)
        {
            if (item.UserId == App.MobileService.CurrentUser.UserId)
            {
                if (item.BookId == deleteAccessBook.id)
                {
                    await BookAccessTable.DeleteAsync(item);
                }
            }
        }
    }
