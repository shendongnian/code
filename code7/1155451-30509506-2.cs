    class Wrapper {
      private volatile object _obj = null;
      public object GetObj() {
        while(_obj == null) {
          // spin, or sleep, or whatever
        }
        return _obj;
      }
      public void SetObj(object obj) {
        _obj = obj;
      } 
    }
    class A {
      private static ConcurrentDictionary<int, Wrapper> _dictionary = new ConcurrentDictionary<int, Wrapper>();
      private int _id;
      private object GetObject() {
        Wrapper wrapper = null;
        if(_dictionary.TryGetValue(_id, wrapper)) {
          return wrapper.GetObj();
        } else {
          Wrapper newWrapper = new Wrapper();
          wrapper = _dictionary.GetOrAdd(_id, newWrapper);
          if(wrapper == newWrapper) {
            wrapper.SetObj(CreateTestObject(_id));
          }
          return wrapper.GetObj();
        }
      }
    }
