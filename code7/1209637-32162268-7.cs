        public int[,] LoadLevelData(string filename)
        {
            using (var streamReader = new StreamReader(filename))
            {
                var serializer = new JsonSerializer();
                return (int[,])serializer.Deserialize(streamReader, typeof(int[,]));
            }
        }
