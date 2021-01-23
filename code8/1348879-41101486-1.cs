            Dictionary<string, string> myDic = new Dictionary<string, string>() {
                { "a","aaaa"},
                { "b","bbbb"},
                { "c","cccc"}
            };
            // populate the dictionary
            var colNames = new List<string>() { "col1", "col2" };
            IEnumerable[] columns = new IEnumerable[2];
            columns[0] = myDic.Keys.ToArray();
            columns[1] = myDic.Values.ToArray();
            REngine engine = REngine.GetInstance();
            var mydata = engine.CreateDataFrame(columns, colNames.ToArray(), stringsAsFactors: false);
