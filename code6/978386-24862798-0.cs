    static class Class1
    {
        public static IList MakeList(this Object t)
        {
            var listType = typeof(List<>);
            var finalType = listType.MakeGenericType(t.GetType());
            var instance = Activator.CreateInstance(finalType);
            return (IList)instance;
        }
    }
