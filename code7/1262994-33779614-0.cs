     protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
     {
         if (e.CommandName == "GetData")
         {
            if (e.CommandSource is Button)
             {
                 ListViewDataItem item = (e.CommandSource as Button).NamingContainer 
                                          as ListViewDataItem;
                 Label NameLabel = item.FindControl("NameLabel") as Label;
                 Label Label5 = item.FindControl("Label5") as Label;
                 //and so on..
             }
        }
    }
