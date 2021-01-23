       private void CheckItemChanged()
       {
           if (
                GridView.CurrentRow != null && 
                GridView.CurrentRow.DataBoundItem != null &&
                GridView.CurrentRow.DataBoundItem.GetType().GetProperty("Active") != null)
           {
               dynamic dataItem = GridView.CurrentRow.DataBoundItem;
               bool value = dataItem.Active;
               dataItem.Active = !value;
            
               Db.SubmitChanges();
         
               RefreshItems();
           }
        }
