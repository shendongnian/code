    static void Main()
    {
        var serializer = new XmlSerializer(typeof(MyData));
        var saveData = new MyData() { Abc = 123 };
        using (var writeFile = File.OpenWrite("data.txt"))
        {
            serializer.Serialize(writeFile, saveData);
        }
        using (var readFile = File.OpenRead("data.txt"))
        {
            var retrieveData = (MyData)serializer.Deserialize(readFile);
            Console.WriteLine(retrieveData.Abc);
        }
    }
    public class MyData
    {
        public int Abc { get; set; }
    }
