    private void OnPostItemClick(object sender, ItemClickEventArgs e)
    {
        // Navigate to cocktail page with item you click/tap on
        Frame.Navigate(typeof(YourPage), e.ClickedItem);
    }
