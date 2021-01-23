    [Serializable]
    public class GenList
    {
        public string Col1 { set; get; }
        public string Col2 { set; get; }
        public GenList DeepClone()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0; //reset stream
                var cloned = formatter.Deserialize(stream) as GenList;
                return cloned;
            }
        }
