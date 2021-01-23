    class BaseData
    {
        private static readonly List<IHaveData> collection = new List<IHaveData>();
        public static IEnumerable<IHaveData> getCollection()
        {
            return collection;
        }
        public static void Register(IHaveData instance)
        {
            collection.Add(instance);
        }
    }
    class SomeImplementation1 : IHaveData
    {
        private static readonly SomeImplementation1 registration = new SomeImplementation1();
        private SomeImplementation1()
        {
            BaseData.Register(this);
        }
        public int[] getSomeData() { return null; }
    }
    class SomeImplementation2 : IHaveData
    {
        private static readonly SomeImplementation2 registration = new SomeImplementation2();
        private SomeImplementation2()
        {
            BaseData.Register(this);
        }
        public int[] getSomeData() { return null; }
    }
