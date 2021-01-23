    foreach (RepeaterItem item in rptServices.Items)
    {
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
           var textbox = (TextBox)item.FindControl("tbx");
           //Do something with your textbox
           textbox.Text = "Test";
        }
    }
