    public class XmlWriterSpy : XmlWriter
    {
        private readonly XmlWriter _originalWriter;
        private readonly XmlTextWriter _buffer;
        private readonly StringWriter _sw;
        public XmlWriterSpy(XmlWriter originalWriter)
        {
            _originalWriter = originalWriter;
            _sw = new StringWriter();
            _buffer = new XmlTextWriter(_sw)
            {
                Formatting = Formatting.Indented
            };
        }
        public override void Flush()
        {
            _originalWriter.Flush();
            _buffer.Flush();
            _sw.Flush();
        }
        public string Xml => _sw?.ToString();
        public override WriteState WriteState => _originalWriter.WriteState;
        public override void Close() { _originalWriter.Close(); _buffer.Close(); }
        public override string LookupPrefix(string ns) { return _originalWriter.LookupPrefix(ns); }
        
        public override void WriteRaw(string data)
        {
            _originalWriter.WriteRaw(data);
            _buffer.WriteRaw(data);
        }
        public override void WriteBase64(byte[] buffer, int index, int count)
        {
            _originalWriter.WriteBase64(buffer, index, count);
            _buffer.WriteBase64(buffer, index, count);
        }
        public override void WriteString(string text)
        {
            _originalWriter.WriteString(text);
            _buffer.WriteString(text);
        }
        public override void WriteSurrogateCharEntity(char lowChar, char highChar)
        {
            _originalWriter.WriteSurrogateCharEntity(lowChar, highChar);
            _buffer.WriteSurrogateCharEntity(lowChar, highChar);
        }
        public override void WriteChars(char[] buffer, int index, int count)
        {
            _originalWriter.WriteChars(buffer, index, count);
            _buffer.WriteChars(buffer, index, count);
        }
        public override void WriteRaw(char[] buffer, int index, int count)
        {
            _originalWriter.WriteRaw(buffer, index, count);
            _buffer.WriteRaw(buffer, index, count);
        }
        public override void WriteStartDocument()
        {
            _originalWriter.WriteStartDocument();
            _buffer.WriteStartDocument();
        }
        public override void WriteStartDocument(bool standalone)
        {
            _originalWriter.WriteStartDocument(standalone);
            _buffer.WriteStartDocument(standalone);
        }
        public override void WriteEndDocument()
        {
            _originalWriter.WriteEndDocument();
            _buffer.WriteEndDocument();
        }
        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            _originalWriter.WriteDocType(name, pubid, sysid, subset);
            _buffer.WriteDocType(name, pubid, sysid, subset);
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            _originalWriter.WriteStartElement(prefix, localName, ns);
            _buffer.WriteStartElement(prefix, localName, ns);
        }
        public override void WriteEndElement()
        {
            _originalWriter.WriteEndElement();
            _buffer.WriteEndElement();
        }
        public override void WriteFullEndElement()
        {
            _originalWriter.WriteFullEndElement();
            _buffer.WriteFullEndElement();
        }
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            _originalWriter.WriteStartAttribute(prefix, localName, ns);
            _buffer.WriteStartAttribute(prefix, localName, ns);
        }
        public override void WriteEndAttribute()
        {
            _originalWriter.WriteEndAttribute();
            _buffer.WriteEndAttribute();
        }
        public override void WriteCData(string text)
        {
            _originalWriter.WriteCData(text);
            _buffer.WriteCData(text);
        }
        public override void WriteComment(string text)
        {
            _originalWriter.WriteComment(text);
            _buffer.WriteComment(text);
        }
        public override void WriteProcessingInstruction(string name, string text)
        {
            _originalWriter.WriteProcessingInstruction(name, text);
            _buffer.WriteProcessingInstruction(name, text);
        }
        public override void WriteEntityRef(string name)
        {
            _originalWriter.WriteEntityRef(name);
            _buffer.WriteEntityRef(name);
        }
        public override void WriteCharEntity(char ch)
        {
            _originalWriter.WriteCharEntity(ch);
            _buffer.WriteCharEntity(ch);
        }
        public override void WriteWhitespace(string ws)
        {
            _originalWriter.WriteWhitespace(ws);
            _buffer.WriteWhitespace(ws);
        }
    }
