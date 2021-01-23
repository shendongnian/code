    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\sandbox\DocumentXml\DocumentXml\Sample.xml";
            using (var stream = File.OpenRead(path))
            {
                var deserializer = new XmlSerializer(typeof(MetaDataXml));
                var data = (MetaDataXml)deserializer.Deserialize(stream);
                foreach (var s in data.Sectors)
                {
                    Console.WriteLine($"Sector Name: {s.SectorName}");
                    foreach (var ss in s.Subsectors)
                    {
                        Console.WriteLine($"Subsector Name: {ss}");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
