    public class ClassWithIds
    {
        public static List<ClassWithIds> Instances = new List<ClassWithIds>();
        private static int _idSeed = 0;
        private readonly string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        private static int NextId()
        {
            return Interlocked.Increment(ref _idSeed);
        }
        public ClassWithIds()
        {
            _name = this.GetType().FullName + " Number " + NextId();
            Instances.Add(this);
        }
    }
