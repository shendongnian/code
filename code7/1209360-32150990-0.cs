    public class ElementSkippingXmlTextWriter : XmlTextWriter
    {
        bool ShouldWriteStartDocument { get; set; }
        readonly Stack<bool> stack = new Stack<bool>();
        readonly Func<string, string, int, bool> filter;
        readonly Func<string, string, int, string> nameEditor;
        public ElementSkippingXmlTextWriter(TextWriter writer, int indentation, char indentChar, bool shouldWriteStartDocument, Func<string, string, int, bool> filter)
            : this(writer, indentation, indentChar, shouldWriteStartDocument, filter, null)
        {
        }
        public ElementSkippingXmlTextWriter(TextWriter writer, int indentation, char indentChar, bool shouldWriteStartDocument, Func<string, string, int, bool> filter, Func<string, string, int, string> nameEditor)
            : base(writer)
        {
            this.Formatting = Formatting.Indented;
            this.Indentation = indentation;
            this.IndentChar = indentChar;
            this.ShouldWriteStartDocument = shouldWriteStartDocument;
            this.filter = filter ?? delegate { return true; };
            this.nameEditor = nameEditor ?? delegate(string localName, string ns, int depth) { return localName; };
        }
        public override void WriteStartDocument()
        {
            if (ShouldWriteStartDocument)
                base.WriteStartDocument();
        }
        public override void WriteStartDocument(bool standalone)
        {
            if (ShouldWriteStartDocument)
                base.WriteStartDocument(standalone);
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            var write = filter(localName, ns, stack.Count);
            var newLocalName = nameEditor(localName, ns, stack.Count);
            if (write)
                base.WriteStartElement(prefix, newLocalName, ns);
            stack.Push(write);
        }
        bool IsFilteredElement { get { return stack.Count > 0 && !stack.Peek(); } }
        public override void WriteEndElement()
        {
            if (stack.Pop())
                base.WriteEndElement();
        }
    }
