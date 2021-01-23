    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var item = e.Item.DataItem as DataRowView;
                    
            var formsection = e.Item.FindControl("formsection") as ListBox;
            formsection.DataSourceID = FormSectionDataSource;
            formsection.DataBind();
            formsection.SelectedValue = item["FormSectionID"].ToString();
        }
        else if (e.Item.ItemType == ListViewItemType.InsertItemTemplate|| 
           e.Item.ItemType == ListViewItemType.EditItemTemplate)
        {   
           ... // Updated
        }
    }
