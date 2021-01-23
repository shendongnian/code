        if (items.Count > 0)
        {
              DataRow dr=null;
              SPListItemCollection ITEM = new SPListItemCollection();
              foreach(SPListItem item in items)
              {
                  string A = item["Approval Status"].ToString();
                  if(A== "2")
                  {
                     ITEM.Add(item);   
                  }
              }
              if(dt.Rows.Count==0)
                 lbldata.Text = "No data to show";
        
                 //  dt = items.GetDataTable();
        
        }
