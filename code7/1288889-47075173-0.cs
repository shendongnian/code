    public class NoEmptyElementsXmlReader : XmlReaderWrapper
    {
        public NoEmptyElementsXmlReader(XmlReader xmlReader)
            : base(xmlReader)
        { }
        public override bool Read()
        {
            bool success = base.Read();
            while (IsEmptyElement && success)
            {
                success = base.Read();
            }
            return success;
        }
    }
