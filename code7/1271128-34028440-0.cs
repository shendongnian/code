        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var guy = e.Item.DataItem as Guy;
            if (guy.Personality is Logician)
            {
                e.Item.FindControl("checkBoxControlId").Visible = true;
            }
            else
            {
                e.Item.FindControl("textBoxControlId").Visible = true;
            }
        }
