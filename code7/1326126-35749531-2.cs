    [TestCleanup()]
            public void MyTestCleanup()
            {
                Dictionary<string, string>.KeyCollection keyColl = ResultsKey.Keys;
                foreach (KeyValuePair<string, string> kvp in ResultsKey)
                {
                    UIMap.ResultsGen(kvp.Value, sFileName, kvp.Key);
                }
                ResultsKey.Clear();
             }
