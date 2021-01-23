    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Item)
       {
           Label lbl = e.Item.FindControl("lblApproved") as Label;
           Button btn = e.Item.FindControl("btnAssignApproved") as Button;
           if (lbl.Text.Equals("Satışa Dönmüştür"))
           {
               btn.Visible = false;
               lbl.ForeColor = System.Drawing.Color.Blue;
           }
       }
    }
