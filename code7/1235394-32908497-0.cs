    public class ListGetter
    {
        private static Dictionary<Type, List<Iab>> dict = new Dictionary<Type, List<Iab>>();
        static ListGetter()
        {
            var classAs = new List<Iab>();
            for (int i = 0; i < 10; i++)
            {
                classAs.Add(new ClassA());
            }
            dict.Add(typeof(ClassA), classAs);
            var classBs = new List<Iab>();
            for (int i = 0; i < 20; i++)
            {
                classBs.Add(new ClassB());
            }
            dict.Add(typeof(ClassB), classBs);
        }
        public static List<T> GetList<T>() where T : Iab
        {
            var list = dict[typeof(T)];
            return list.Cast<T>().ToList();
        }
    }
