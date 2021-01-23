    if(SelectedListViewItem != null)
    {
        // EDIT: Typo in the lambda for FirstOrDefault
        var delete = showList.FirstOrDefault(x => SelectedListViewItem.ShowName == x.ShowName);
        if(delete != null)
        {
            ((ObservableCollection<GetterSetter>)listView.ItemsSource).Remove(delete);
        }
    }
