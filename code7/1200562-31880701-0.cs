      public class TestObjectCollection: List<TestObject>
      {
         public TestObjectCollection(IEnumerable<TestObject> list) { AddRange(list);}
         ...
      }
