    class Foo
    {
        public bool IsArray { get; set; }
        public object Values { get; set; }
    
        public IEnumerable<String> GetValues() 
        {
          if (null == values)
              yield break;
    
          List<String> list = Values as List<String>;
    
          if (list != null)
              foreach (var item in list)
                  yield return item;
          else
              yield return Values as String;
        }
    }
