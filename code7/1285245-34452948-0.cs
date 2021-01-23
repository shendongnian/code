    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Save(string filePath)
        {
            var formatter = new BinaryFormatter();
            using (var stream = File.Open(filePath, FileMode.Create))
                formatter.Serialize(stream, this);
        }
        public static Person ReadFromFile(string filePath)
        {
            var formatter = new BinaryFormatter();
            using (var stream = File.OpenRead(filePath))
                return (Person)formatter.Deserialize(stream);
        }
    }
