    public static class Orders
    {
        private static ListItemCollection _load;
        public static ListItemCollection Load{ get{return _load??(_load = LoadListItemCollection());}
        
        public static ListItemCollection LoadListItemCollection()
        //your code
    }
