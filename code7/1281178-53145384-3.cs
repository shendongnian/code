          public static class ObjectExtensions
          {
            public static T DataSnapshotToObject<T>(IEnumerable<DataSnapshot> source)
            where T : class, new()
            {
            var someObject = new T();
            var someObjectType = someObject.GetType();
            foreach (var item in source)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value.ToString(), null);
            }
            return someObject;
        }
    }
