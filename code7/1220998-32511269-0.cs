    public static class DataTableExtensions
    {
        public static void WriteXml(this DataTable dt, XmlWriter writer, XName rootName, IEnumerable<XAttribute> rootAttributes = null)
        {
            if (dt == null || writer == null || rootName == null)
                throw new NullReferenceException();
            var doc = new XDocument();
            using (var docWriter = doc.CreateWriter())
            {
                dt.WriteXml(docWriter);
            }
            if (doc.Root != null)
            {
                doc.Root.Name = rootName;
                if (rootAttributes != null)
                    doc.Root.Add(rootAttributes);
            }
            doc.WriteTo(writer);
        }
    }
