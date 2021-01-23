        protected void RPClientWish_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                try
                {
                    if(Convert.ToInt32(Session["RoleId"])==1)
                    {
                     if(e.Item.ItemType == ListItemType.Header)
                       {
                        Label lb2 = (Label)e.Item.FindControl("lb2");
                        lb2.Visible = true;
                       }
                     else if(e.Item.ItemType == ListItemType.Item)
                       {
                        Label lbBillableAmount1 = (Label)e.Item.FindControl("Label7");
        
                        lbBillableAmount1.Visible = true;
                      }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
