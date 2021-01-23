    void listviews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Bookings SelectedBook = (Bookings)listviews.SelectedItem;
        var abc = SelectedBook.ID;
    }
