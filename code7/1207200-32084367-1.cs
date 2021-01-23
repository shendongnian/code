    public static class Orders
    {
        private static ListItemCollection _cache;
        public static ListItemCollection Cache{ get{return _cache??(_cache = LoadListItemCollection());}
        
        public static ListItemCollection LoadListItemCollection()
        //your code
    }
    // One more apporach
    public static class Orders
    {
        private static ListItemCollection _cache;
        public static ListItemCollection Cache{ get{return _cache??LoadListItemCollection(true);}
        
        public static ListItemCollection LoadListItemCollection(bool refreshList=false)
        { 
              if(!refreshList && _cache!=null)
              {
                   return Cache;
              }
              //your code
              ListItemCollection collListItem = list.GetItems(query);
              //your code
              _cache = collListItem;
              return collListItem;
        }
    }
