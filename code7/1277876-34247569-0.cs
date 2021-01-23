    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb2 = new System.Text.StringBuilder();
            XmlDocument doc = new XmlDocument();
            // --- XML with instruction -> Parsing fails 
            sb2.AppendLine(@"<MetalQuote xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.xignite.com/services"" >");
            sb2.AppendLine(@"<Outcome>Success</Outcome>");
            sb2.AppendLine(@"<Ask>1073.3</Ask>");
            sb2.AppendLine(@"</MetalQuote>");
            doc.LoadXml(sb2.ToString());
            // Create a manager
            XmlNamespaceManager xnm = new XmlNamespaceManager(doc.NameTable);
            xnm.AddNamespace("abc", @"http://www.xignite.com/services");
            // Use the namespace for each node
            System.Diagnostics.Debug
                .WriteLine(doc.SelectSingleNode(@"//abc:MetalQuote/abc:Outcome", xnm).InnerText);
        }
    }
