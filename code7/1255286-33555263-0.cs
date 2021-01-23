    private void ItemClick(object sender, ItemClickEventArgs e)
    {
        var clickedElement = (e.OriginalSource as FrameworkElement);
        YourItemClass item = clickedElement.DataContext as YourItemClass;
        // if your item contains a Name/Id/other you can pass that when navigating
        // you can also pass index of your item in collection if you need
        Frame.Navigate(typeof(DetailedPage), item.Id);
    }
