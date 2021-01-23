        public async void LoadModelListPAR()
        {
            var lines = File.ReadAllLines(@"D:\jobs\modelList");
            modelData = new List<ModelData>();
            foreach(var line in lines)
            {
                string modelName = line.Split('_')[2].Replace("-1m", "");
                await LoadTrades(modelName, @"D:\jobs\" + line);
            };
        }
        public async Task LoadTrades(string modelName, string modelDir)
        {
            using (var f = new FileStream(path: modelDir + "\\trades.txt", mode: FileAccess.Read, isAsync: true))
            {
                var buf = new byte[f.Length];
                await f.ReadAsync(buf, 0, f.Length);
                var s = Encoding.UTF8.GetString(buf);
                foreach (var line in s.Split('\n'))
                {
                    modelData.Add(new ModelData(line));
                }
            }
        }
