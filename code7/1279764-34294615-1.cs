    class Program
    {
        static void Main(string[] args)
        {
            var line = File.ReadLines(yourFileName).First();
            var correctXml = line + "<Root></Root>";
            var xml= XDocument.Parse(correctXml);
            var version = xml.Declaration.Version;
            var encoding = xml.Declaration.Encoding;
            var standalone = xml.Declaration.Standalone;
        }
    }
