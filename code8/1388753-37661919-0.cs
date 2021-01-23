        public static IAsyncOperation<IDictionary<string, int>> TestFunction2()
        {
            return AsyncInfo.Run<IDictionary<string, int>>((token) =>
                Task.Run<IDictionary<string, int>>(() =>
                {
                    return AddDictionary();
                }, token)
            );
        }
        //private static async Task<IDictionary<string, int>> AddDictionary()
        private static IDictionary<string, int> AddDictionary()
        {
            IDictionary<string, int> testDictionary = new Dictionary<string, int>();
            testDictionary.Add("value1", 23);
            testDictionary.Add("value2", 1986);
            return testDictionary;
        }
