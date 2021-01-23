    namespace DocumentXml
    {
        class Program
        {
            static void Main(string[] args)
            {
                var path = @"D:\sandbox\DocumentXml\DocumentXml\Sample.xml";
                var serializer = new XmlSerializer(typeof(Document));
                var document = serializer.Deserialize(File.OpenRead(path)) as Document;
                var sectors = document.Sectors;
                foreach (var s in sectors)
                {
                    Console.WriteLine($"Sector Name: {s.SectorName}");
                    foreach (var ss in s.Subsectors)
                    {
                        Console.WriteLine($"Subsector Name: {ss}");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
    }
