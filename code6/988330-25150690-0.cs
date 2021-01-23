     //IDataObject is an interface to provide a common contract for all entities used
     public static object GetData<T as IDataObject>()
     {
         var mgr = new DataManager<T>();
         return mgr.List();
     }
