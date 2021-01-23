    try
    {
        var l = yourobject.GetMenuItemsFromLevel(ReturnMenuType.Unknown);
    }
    catch(ArgumentOutOfRangeException ex)
    {
        //handle your exception
        MessageBox.Show(ex.Message);
    }
