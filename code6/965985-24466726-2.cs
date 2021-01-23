       if (Datagrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < Datagrid.SelectedItems.Count; i++)
                {
                   System.Data.DataRowView selected = 
                           (System.Data.DataRowView)Datagrid.SelectedItems[i];
                     str = Convert.ToString(selected.Row.ItemArray[n]);
                     // get the int value
                     int a = Convert.ToInt32(str);
                }
             
            }
