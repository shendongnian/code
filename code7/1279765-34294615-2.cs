    class Program
    {
        static void Main(string[] args)
        {
            var line = File.ReadLines(YourFileName).First();
            var correctXml = line + "<Root></Root>";
            var xml = XDocument.Parse(correctXml);
            var stringEncoding = xml.Declaration.Encoding;
            var encoding = System.Text.Encoding.GetEncoding(stringEncoding);
        }
    }
