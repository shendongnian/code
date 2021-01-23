    [TestMethod]
            public void Test()
            {
                var test = new ConcurrentDictionary<KeyValuePair<long, long>, IList<string>>();
                test.TryAdd(new KeyValuePair<long, long>(1, 1), new List<string> { "Test" });
    
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ContractResolver = new DictionaryAsArrayResolver();
    
                var se = SerializeObject(test, settings);
    
                var de = DeserializeObject<ConcurrentDictionary<KeyValuePair<long, long>, IList<string>>>(se, settings);
            }
