    protected void ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label label12 = (Label)((Repeater)sender).Controls[0].Controls[0].FindControl("label12");;
            Label activeLabel = (Label)e.Item.FindControl("lblEditor");
            string s = activeLabel.Text;
            if (s != "Sao Palo")
            {
                activeLabel.Visible = true;
                label12.Visible = true;
            }
            else
            {                    
                activeLabel.Visible = false;
                label12.Visible = false;   
            }
        }
    }
