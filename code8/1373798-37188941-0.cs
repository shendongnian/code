    interface IDBObject
    {
         string GetDBType()
    }
    
    then have your required classes and implement respect interface
    
    public class SQLStoreProc:IDBObject
    {
         public string GetDBType()
         {}
    }
    
    public class SQLFunction:IDBObject
    {
    public string GetDBType()
         {}
    }
    
    public class SQLMisc:IDBObject
    {
    public string GetDBType()
         {}
    }
