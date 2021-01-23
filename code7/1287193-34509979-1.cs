        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""iso-8859-1""?>
    <ResDoc>
    <Summary>
    My name is Magesh
    </Summary>
    </ResDoc>";
            XDocument doc = XDocument.Parse(xml);
            var element = doc.Element("ResDoc").Element("Summary");
            element.Value = element.Value.Replace("Magesh", "YourName");
            Console.WriteLine(element.Value);
            Console.ReadKey();
            
        }
