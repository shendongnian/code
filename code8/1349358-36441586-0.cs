    private async void DeleteShared_Tapped(object sender, RoutedEventArgs e)
    {
        deleteAccessBook = (e.OriginalSource as FrameworkElement)?.DataContext as Book;
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
