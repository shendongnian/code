    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            Button btn = (Button)e.Item.FindControl("AddNewRecordButton");
            btn.Attributes.Add("onClick", "test()");
    
            LinkButton linkBtn = (LinkButton)e.Item.FindControl("InitInsertButton");
            linkBtn.Attributes.Add("onClick", "test()");
        }
    }
