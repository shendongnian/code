    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Separator)
        {
            //Compare last and current date                    
            isOtherDate = ((MyType)e.Item.DataItem).MyDate.Date != lastShowedDate.Value.Date;
            //Save current date for next item comparison
            lastShowedDate = ((MyType)e.Item.DataItem).MyDate;
            e.Item.Visible = isOtherDate; 
        }
    }
