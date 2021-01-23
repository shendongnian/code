     foreach (RepeaterItem item in repeater1.Items)
       {             
      if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
         {
              TextBox txtName = (TextBox)item.FindControl("txtQuantity");
              if (txtName!= null)
               {
                 strText = strText + ", " + txtName.Text;
                 Response.Write("Text =" + strText);
               }
          }
       }
