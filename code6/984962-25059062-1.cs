    ObservableCollection<Object> obsObject = CR.GetListObject(Id);
    LV_LIST_OBJECT.SelectAll();
    foreach(var Item in LV_LIST_OBJECT.Items)
    {
       bool bFound = false;
       if(Item.GetType() == typeof(Object))
       {
           foreach(Object obj in obsObject)
           {
               if (((Object)Item).ID_Object == obj.ID_Object)
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
