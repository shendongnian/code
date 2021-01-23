    public int GetSelectedItemsPrimaryKey(object selectedItem)
    {
        if (selectedItem is Order)
        {
            return (selectedItem as Order).OrderPrimaryKey;
        }
        else if (selectedItem is Product)
        {
            return (SelectedItem as Product).ProductPrimaryKey;
        }
        //.....
    }
