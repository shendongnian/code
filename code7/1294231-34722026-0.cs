    void radPropertyGrid1_ItemFormatting(object sender, PropertyGridItemFormattingEventArgs e)
    {
        if (e.Item is PropertyGridGroupItem)
        {
            if (e.Item.Label == "Datos")
            {
                e.Item.Label = "Date";
            }
        }
    }
