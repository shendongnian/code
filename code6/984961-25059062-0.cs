    ObservableCollection<Object> obsObject = CR.GetListObject(Id);
    LV_LIST_OBJECT.SelectAll();
    foreach(var Item in LV_LIST_OBJECT.Items)
    {
       bool bFound = false;
       if(Item.GetType() == typeof(Object))
       {
           foreach(T_LOT lot in obsLot)
           {
               if (((Object)Item).ID_Object == lot.ID_Object)
               {
                   bFound = true;
                   break;
               }
       }
       if(!bFound)
       {
           LV_LIST_Object.SelectedItems.Remove(Item);
       }
    }
