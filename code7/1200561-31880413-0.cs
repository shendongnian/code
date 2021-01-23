    public static class TestEnumerable
    {
         public static TestObjectCollection ToTestObjectCollection(this IEnumerable<TestObject> source)
         {
             return new TestObjectCollection(source);
         }
    }
