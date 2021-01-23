    protected void rptSlider_ItemDataBound(object sender, RepeaterItemEventArgs e) {
          // This event is raised for the header, the footer, separators, and items.
          // Execute the following logic for Items and Alternating Items.
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            //get the item from the event arguments
            var item = (Slider)e.Item.DataItem;
            //get the controls
            var lblTitle = (Label)e.Item.FindControl("lblTitle");
            var lblDescription= (Label)e.Item.FindControl("lblDescription");
            var framevid= (HtmlGenericControl)e.Item.FindControl("framevid");
            var sldr= (HtmlGenericControl)e.Item.FindControl("sldr");
            var daslider= (HtmlGenericControl)e.Item.FindControl("daslider");
            lblTitle.Text = item.SliderTitle;
            lblDescription.Text = item.SliderDescription;
            framevid.Attributes.Add("src", item.SliderImage);
            sldr.Attributes.Add("src", item.SliderImage);
            daslider.Style.Add("background-image", WebUtility.UrlSchemeAuthority() + @"/FileStore/AppSettingsSiteLogos/" + item.BackgroundImage);
          }
       } 
