    private IEnumerable<T> LoadData<T>(IEnumerable<T> list, IDataLoader loader)
    { 
         ...
    }
    
    interface IDataLoader 
    {
          StreamReader Load(...);
          StreamWriter Save(...); 
    }
    
