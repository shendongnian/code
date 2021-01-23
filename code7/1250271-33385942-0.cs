    protected void RPClientWish_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
         if (e.Item.ItemType == ListItemType.Item)
          {
            try
            {
                if(Convert.ToInt32(Session["RoleId"])==1)
                {
                    Label lb2 = (Label)e.Item.FindControl("lb2");
                    lb2.Visible = true;
                    Label lbBillableAmount1 = (Label)e.Item.FindControl("Label7");
    
                    lbBillableAmount1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
          }
        }
