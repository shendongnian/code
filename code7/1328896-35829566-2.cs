    public static class XmlReaderExtensions
    {
        public static void EnsureRead(this XmlTextReader reader)
        {
            var isRead = reader.Read();
            if (!isRead)
                throw new InvalidOperationException("Failed to read");
        }
        public static void SkipUntil(this XmlTextReader reader, Func<XmlTextReader, Boolean> isStop)
        {
            while (!isStop(reader))
            {
                reader.EnsureRead();
            }
        }
    }
...
    var xml = @"<root>   <key>businessAddress</key>
        <string>Moka</string>
        <key>businessName</key>
        <string>Moka address</string>
        <key>Id</key>
        <string>39</string>
        <key>Cat</key>
        <string>216</string>
        <key>deals</key> </root>";
    using (var stream = new MemoryStream(Encoding.Default.GetBytes(xml)))
    using (var reader = new XmlTextReader(stream))
    {
        reader.SkipUntil(cur => cur.Value == "Id");
        reader.EnsureRead(); // Skip current node
        reader.SkipUntil(cur => cur.NodeType == XmlNodeType.Text);
        Console.WriteLine("The id from XmlTextReader is {0}", reader.Value);
    }
