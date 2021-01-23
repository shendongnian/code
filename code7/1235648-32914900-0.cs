    internal class TestData
    {
        private static Dictionary<Type, object> mTestData = new Dictionary<Type, object>();
    
        internal static void Add<T>(T _testData) where T: ValueType
        {
            mTestData.Add(typeof(T), _testData);
        }
    
        internal static void Fill<T>(ref T _runtimeData) where T: ValueType
        {
            T testData = (T)mTestData[typeof(T)];
            _runtimeData = testData;
        }
    }
