    partial class NewDataSet
    {
        [XmlIgnore]
        public XNode schema { get; set; }
        public static NewDataSet Read(string path)
        {
            var xml = XElement.Load(path);
            var schema = xml.FirstNode;
            xml.FirstNode.Remove();
            string xmlstring = xml.ToString();
            var ret = NewDataSet.Deserialize(xmlstring);
            ret.schema = schema;
            return ret;
        }
        public void Write(string path)
        {
            var XmlString = this.Serialize();
            var xml = XElement.Parse(XmlString);
            xml.AddFirst(this.schema);
            xml.Save(path);
        }
    }
