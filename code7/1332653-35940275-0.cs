        public MyItemType CurrentItem 
        {
           get {
              return _CurrentItem; 
           }
           set { 
              _CurrentItem = value; 
              if(_CurrentItem != null)
                 MyObjects = LoadMyObjects(_CurrentItem.ID);
              else
                 MyObjects = null;
           }
        }
