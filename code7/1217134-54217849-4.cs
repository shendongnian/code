    public abstract class TESTAbstract 
    {
        //overall list of elements
        public static List<TESTAbstract> Elements = new List<TESTAbstract>();
        public static int Count { get; private set; }
        public int localId { get; protected set; }
        public int globalId { get; protected set; }
        //members here
        public int someValue = 0;
        public TESTAbstract()
        {
            globalId = Count; Count++;
            Elements.Add(this);
        }
    }
    public abstract class TESTAbstract<T> : TESTAbstract where T : TESTAbstract
    {
        new public static List<T> Elements = new List<T>();
        new public static int Count { get; private set; }
        public TESTAbstract()
            : base()
        {
            localId = Count; Count++;
            Elements.Add(this as T);
        }
    }
