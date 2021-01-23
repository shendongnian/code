      if (innerItem != null)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // this creates a link to the page in sitecore once clicked
                HyperLink topNavigation = (HyperLink)e.Item.FindControl("innerHyperLink");
                topNavigation.NavigateUrl = LinkManager.GetItemUrl(innerItem);
                topNavigation.Text = innerItem["Title"];
  
            }
        }
