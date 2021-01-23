    protected void ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Label label12 = (Label)e.Item.FindControl("label12");
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
