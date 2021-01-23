    class A {
      private static ConcurrentDictionary<int, object> _dictionary = new ConcurrentDictionary<int, object>();
      private int _id;
      private object getObject() {
        object output = null;
        if(_dictionary.TryGetValue(_id, output)) {
          return output;
        } else {
          return _dictionary.GetOrAdd(_id, CreateTestObject(_id));
        }
      }
    }
