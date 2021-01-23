    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.AlternatingItem || 
           e.Item.ItemType == ListItemType.Item)
        {
           HtmlGenericControl TeklifId = e.Item.FindControl("TeklifId") as HtmlGenericControl;
           string TeklifId = TeklifId.InnerText;  //value here
        }
    }
