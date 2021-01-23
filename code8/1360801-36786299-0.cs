      foreach (RepeaterItem item in repeater1.Items)
           {             
          if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
             {
                   TextBox txtName = (TextBox)item.FindControl("txtComment");
                    if (txtName != null)
                    {
                        lblCheck.Text= txtName.Text;
                    }
              }
           }
