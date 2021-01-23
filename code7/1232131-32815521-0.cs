    foreach (ListItem item in this.ColumnsList.Items)
    {
        if (item.Selected)
        {
            item.Attributes.Add("style", "Color: Red");
        }
    }
