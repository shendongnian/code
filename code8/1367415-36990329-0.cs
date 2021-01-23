    public MyEnum {
      A,
      B
    }
    
    [BsonDictionaryOptions(DictionaryRepresentation.Document)]
    public MyDictionary<String, MyEnum, object> MyData {get;set;}
   
    public class MyDictionary<T1,T2,T3> : IDictionary{
        Dictionary<T1, T3> Dict = new Dictionary<T1, T3>();
        //implement dictionary...
    }
