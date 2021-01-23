    foreach(var item in ComboBoxControl.Items)
    {
        CustomBoxItem castedItem  = item as CustomBoxItem;
        if(null != castedItem)
        {
            var supplier = castedItem.SupplierID;
        }
    }
