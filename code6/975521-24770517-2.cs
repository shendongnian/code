    class Program
    {
        public static Vec3 SuperVector = new Vec3 { 2, 5, 6 };
        static void Main(string[] args)
        {
            Console.WriteLine(SuperVector[0]);
            Console.WriteLine(SuperVector[1]);
            Console.WriteLine(SuperVector[2]);
            Console.ReadLine();
        }
    }
    public struct Vec3: IEnumerable
    {
        List<float> MyVals;
        
        public float this[int a]
        {
            get
            {
                return MyVals[a];
            }
            set
            {
                InitiailaizeMyValIfEmpty();
                MyVals[a] = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Add(float f)
        {
            InitiailaizeMyValIfEmpty();
            MyVals.Add(f);
        }
        private void InitiailaizeMyValIfEmpty()
        {
            if (MyVals == null)
                MyVals = new List<float>();
        }
    }
