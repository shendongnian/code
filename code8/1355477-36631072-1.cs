        public static T Parse<T>(Stream stream, Func<bool> checkCancelled)
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new CancellableJsonTextReader(sr, checkCancelled))
            {
                var result = serializer.Deserialize<T>(jsonTextReader);
                return result;
            }
        }
