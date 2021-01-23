    static void Main(string[] args)
        {
            string UserInput = "someCreteria";
            using (var xmlStream = new FileStream(@"c:\temp\peoples.xml", FileMode.Open))
            {
                using (var xmlReader = new XmlTextReader(xmlStream))
                {
                    XDocument doc = XDocument.Load(xmlReader);
                    var result = doc.Descendants().AsParallel().Where(x => x.Value.Equals(UserInput)).FirstOrDefault();
                    if (result == null)
                        Console.WriteLine("No item found");
                    else
                        Console.WriteLine(result.Value.ToString());
                }
            }
            Console.ReadKey();
        }
