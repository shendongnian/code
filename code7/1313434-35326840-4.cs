    class myItemWrapper
    {
         private myItem _myItem;
         public myItemWrapper(myItem item)
         {
             _myItem = item;
         }
         public override string ToString()
         { 
             return _myItem.data.Name;
         }
         public myItem Item { get { return _myItem;}}
    }
