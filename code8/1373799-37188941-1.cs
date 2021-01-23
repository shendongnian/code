    class clsFactory
    {
         public static IDBObject CreateObject(string type)
         {
          IDBObject ObjSelector = null;
    
            switch (type)
            {
                case "SP":
                    ObjSelector = new SQLStoreProc();
                    break;
                case "FUNC":
                    ObjSelector = new SQLFucntion();
                    break;
                default:
                    ObjSelector = new SQLMisc();
                    break;
            }
            return ObjSelector;
         }
    }
