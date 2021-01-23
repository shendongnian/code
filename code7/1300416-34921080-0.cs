    class Program
    {
        static void Main(string[] args)
        {
            var genericList = new List<String>() {"a", "b"};
            var listImplementation = new MyList();
    
            var resultGeneric = genericList.RemoveWhere(x => x.Contains("s"));
            var resultImplemented = listImplementation.RemoveWhere(x => x.Equals(1));
        }
    }
    
    class MyList : IList
    {
       ...
    }
    
    public static class JTest
    {
        public static IList RemoveWhere(this IList list, Func<object, bool> predicate, int offset = 0)
        {
            return list;
        }
    
        public static IList<T> RemoveWhere<T>(this IList<T> list, Func<T, bool> predicate, int offset = 0)
        {
            return list;
        }
    }
