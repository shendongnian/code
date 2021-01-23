    interface IItem { 
       int Property {
           get;
          set;
       }
    }
    class Item1 : IItem {
        public int Property {
            get;
           set;
        }
    }
    class Item2 : IItem {
        public int Property {
            get;
           set;
        }
    }
    IItem item = (IItem)Activator.CreateInstance(Type.GetType("eStartService." + tableName));
    item.Property1 = ...;
