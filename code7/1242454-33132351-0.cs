    protected void rptSlides_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.AlternatingItem 
                                               || e.Item.ItemType == ListItemType.Item)
       {
           HtmlControl slideTextdiv = (HtmlControl)e.Item
                                                    .FindControl("slideTextdiv");
           HtmlGenericControl titlePlaceHolder = (HtmlGenericControl)e.Item
                                                    .FindControl("titlePlaceHolder");
           HtmlGenericControl textPlaceHolder = (HtmlGenericControl)e.Item
                                                    .FindControl("textPlaceHolder");
           if (String.IsNullOrEmpty(titlePlaceHolder.InnerText) && 
                                          String.IsNullOrEmpty(textPlaceHolder.InnerText))
           {
               slideTextdiv.Visible = false;
           }
       }
    }
