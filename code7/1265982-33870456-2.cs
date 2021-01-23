        if (items.Count > 0)
        {
              DataRow dr=null;
              SPListItemCollection ITEM = ... //
              foreach(SPListItem item in items)
              {
                  string A = item["Approval Status"].ToString();
                  if(A== "2")
                  {
                     SPListItem myItem = ITEM.Add();
                     // set your item's fields here 
                     // Use indexers on this object for each field to assign specific values, and then call the Update method on the item to effect changes in the database.
                     myItem["Approval Status"] = item["Approval Status"];
                     ...
                     myItem.Update();
                  }
              }
              if(dt.Rows.Count==0)
                 lbldata.Text = "No data to show";
        
                 //  dt = items.GetDataTable();
        
        }
