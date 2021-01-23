    public class ListGetter2
    {
        private static IList<Iab> _list;
        static ListGetter2()
        {
            _list = new List<Iab>();
            for (int i = 0; i < 10; i++)
            {
                _list.Add(new ClassA());
            }
            for (int i = 0; i < 20; i++)
            {
                _list.Add(new ClassB());
            }
        }
        public static IList<T> GetList<T>() where T : Iab
        {
            return _list.OfType<T>().ToList();
        }
    }
