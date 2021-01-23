    public class Parameter<K,V>{
      public Dictionary<K,V> Values {get; set;}
      
      public Parameter()
      {
         Values = new Dictionary<K,V>();
      }
      public void AddParameter(K key, V value)
      {
         Values.Add(key,value);
      }
      ...Other access methods here
    }
