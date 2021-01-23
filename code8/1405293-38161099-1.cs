    public partial class webParts
    {
        static public webParts FromXml(string path)
        {
            webParts returnValue = null;
            var serializer = new XmlSerializer(typeof(webParts));
            using (var stream = File.OpenRead(path))
            {
                returnValue = (webParts)serializer.Deserialize(stream);
            }
            return returnValue;
        }
    }
