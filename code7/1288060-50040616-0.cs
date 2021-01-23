    public async Task WriteToDictionaryAsync(Dictionary<string, string> dictionary, StorageFile binarySourceFile)
        {
            await Task.Delay(5);
            using (FileStream fs = File.OpenWrite(binarySourceFile.Path))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Put count.
                writer.Write(dictionary.Count);
                // Write pairs.
                foreach (var pair in dictionary)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }
        public async void WriteToDictionary(Dictionary<string, string> dictionary, StorageFile binarySourceFile)
        {
            await Task.Delay(5);
            using (FileStream fs = File.OpenWrite(binarySourceFile.Path))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Put count.
                writer.Write(dictionary.Count);
                // Write pairs.
                foreach (var pair in dictionary)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }
        public async Task<Dictionary<string, string>> ReadDictionaryAsync(StorageFile binarySourceFile)
        {
            await Task.Delay(5);
            var result = new Dictionary<string, string>();
            using (FileStream fs = File.OpenRead(binarySourceFile.Path))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                // Get count.
                int count = reader.ReadInt32();
                // Read in all pairs.
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    string value = reader.ReadString();
                    result[key] = value;
                }
            }
            return result;
        }
        public Dictionary<string, string> ReadDictionary(StorageFile binarySourceFile)
        {
            var result = new Dictionary<string, string>();
            using (FileStream fs = File.OpenRead(binarySourceFile.Path))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                // Get count.
                int count = reader.ReadInt32();
                // Read in all pairs.
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    string value = reader.ReadString();
                    result[key] = value;
                }
            }
            return result;
        }
