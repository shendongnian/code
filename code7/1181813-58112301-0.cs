    public class ArgCapture<T>
    {
        private List<T> m_arguments = new List<T>();
        public T capture()
        {
            T res = Arg.Is<T>(obj => add(obj)); // or use Arg.Compat.Is<T>(obj => add(obj)); for C#6 and lower
            return res;
        }
        public int Count
        {
            get { return m_arguments.Count; }
        }
        public T this[int index]
        {
            get { return m_arguments[index]; }
        }
        public List<T> Values {
            get { return new List<T>(m_arguments);}
        }
        private bool add(T obj)
        {
            m_arguments.Add(obj);
            return true;
        }
    }
