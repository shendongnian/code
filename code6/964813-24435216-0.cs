    private void MusicListSelectChange(object sender, SelectionChangedEventArgs e)
    {
            Model.MusicItem item = ((LongListSelector)sender).SelectedItem as Model.MusicItem;
            if (item == null)
                return;
            if (isItemCloseTapped )
            {
                CloseInList(item);
                isItemCloseTapped = false;
            }
            //...
            //((LongListSelector)sender).SelectedItem = null;
    )
