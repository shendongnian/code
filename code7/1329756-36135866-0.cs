    protected void rpDB_item_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlGenericControl dbOnline = ((HtmlGenericControl)e.Item.FindControl("dbOnline"));
            HtmlGenericControl sfile = ((HtmlGenericControl)e.Item.FindControl("lblfile"));
            //HtmlGenericControl online = ((HtmlGenericControl)e.Item.FindControl("dbOnline"));
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                
                string sonline = (string)(DataBinder.Eval(e.Item.DataItem, "Online/Offline").ToString());
                string myfile = (string)(DataBinder.Eval(e.Item.DataItem,"FileName"));
               
                if (sonline == "Online")
                {
                    sfile.Attributes.Add("class", "green");
                    dbOnline.Attributes.Add("class", "led-green");
                }           
            }
        }
