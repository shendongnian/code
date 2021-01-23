    ICollectionView view = CollectionViewSource.GetDefaultView(customerList);
    view.Filter = obj =>
    {
        string item = obj as string;
        return (item.ToLower().Contains(YourFilter));
    };
