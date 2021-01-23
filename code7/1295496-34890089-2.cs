    class Program
    {
        static void Main(string[] args)
        {
            string test = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <note>
        <to>Tove</to>
    <from>Jani</from>
        <heading>Reminder</heading>
    <body>Don't forget me this weekend!</body>
    </note>";
            string output = Test.BeautifyXML(test);
            Console.Write(output);
            Console.ReadLine();
        }
    }
    static class Test { 
        static public string BeautifyXML(this string docString)
        {
            docString = Regex.Replace(docString.Replace("\r", "<r></r>").Replace("\n", "<n></n>"),@"\?>(<r></r><n></n>)*", "?>");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(docString);
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return Regex.Replace(sb.ToString().Replace("\r\n", ""), @"<r></r>( )*<n></n>", "\r\n").Replace("?>", "?>\r\n");
        }
    }
