    if (AContact.cnt_Key == 0)
    {
        FSelectedContact = InvalidList[0];
        NotifyPropertyChanged();
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            SelectedItemIndex = BastardIndex));
    }
    BastardIndex++;
