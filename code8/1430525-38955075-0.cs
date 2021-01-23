    class Base<T> where T : Base<T>, ISource, new()
    {
        public static List<T> Read()
        {
            // here I create an Instance to be able to call the Methods of T
            string source = (new T()).GetSource();
            return GetResource(source);
        }
    }
