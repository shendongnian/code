    internal class TestData
    {
        private static Dictionary<Type, object> mTestData = new Dictionary<Type, object>();
    
        internal static void Add<T>(T _testData) where T: ValueType, struct
        {
            mTestData.Add(typeof(T), _testData);
        }
    
        internal static void Fill<T>(ref T _runtimeData) where T: ValueType, struct
        {
            T testData = (T)mTestData[typeof(T)];
            _runtimeData = testData;
        }
    }
