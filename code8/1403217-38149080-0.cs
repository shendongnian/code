    private void OnBindingContextChanged(object sender, EventArgs e)
    {
        base.OnBindingContextChanged();
        if (BindingContext == null)
            return;
        ViewCell theViewCell = ((ViewCell)sender);
        var item = theViewCell.BindingContext as ListItemModel;
        theViewCell.ContextActions.Clear();
        if (item != null)
        {
            if (item.ListItemType == ListItemTypeEnum.FavoritePlaces
               || item.ListItemType == ListItemTypeEnum.FavoritePeople)
            {
                theViewCell.ContextActions.Add(new MenuItem()
                {
                    Text = "Delete"
                });
            }
        }
    }
