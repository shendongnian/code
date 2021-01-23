    public class Service
    {
       private static Lazy<List<SomeType>> _list = new Lazy<List<SomeType>>(
           ()=>FunctionToGetSomeTypeValue(),
           isThreadSafe: true
       );
    
       public static List<SomeType> GetSomeTypeList()
       {
          return _list.Value;
       }
    }
