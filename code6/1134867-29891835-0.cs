    public class CompositeXmlWriter : XmlWriter
    {
        private readonly IEnumerable<XmlWriter> writers;
        public CompositeXmlWriter(IEnumerable<XmlWriter> writers)
        {
            this.writers = writers;
        }
        public override void WriteStartDocument()
        {
            foreach (var writer in writers)
            {
                writer.WriteStartDocument();
            }
        }
        public override void WriteEndDocument()
        {
            foreach (var writer in writers)
            {
                writer.WriteEndDocument();
            }
        }
        ...Implement all other methods
    }
