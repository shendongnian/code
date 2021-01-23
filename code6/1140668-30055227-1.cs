    private void repSubsidiaryList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
       // Cast the current dataitem to a Sitecore item
       Item item = (Item)e.Item.DataItem; 
       Repeater innerRpt = (Repeater) e.Item.FindControl("InnerRepeater");      
       // bind the inner repeater to the children of the sitecore item
       innerRpt.DataSource = item.Children; 
       innerRpt.DataBind();
    }
