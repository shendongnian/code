    public static void SerializeObject(this List<string> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<string>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }
        public static void Deserialize(this List<string> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<string>));
            using (var stream = File.OpenRead(fileName))
            {
                var other = (List<string>)(serializer.Deserialize(stream));
                list.Clear();
                list.AddRange(other);
            }
        }
