    class BaseData
    {
        private static readonly List<IHaveData> collection = new List<IHaveData>
        {
            new SomeImplementation1(),
            new SomeImplementation2()
            //as you add more implementations, you'll need to add them here
        };
        public static IEnumerable<IHaveData> getCollection()
        {
            return collection;
        }
    }
