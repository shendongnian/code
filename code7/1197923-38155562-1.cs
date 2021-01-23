    public class CleanTextReader : StreamReader
    {
        public CleanTextReader(Stream stream) : base(stream)
        {
        }
        public override int Read()
        {
            var val = base.Read();
            return XmlConvert.IsXmlChar((char)val) ? val : (char)' ';
        }
        public override int Read(char[] buffer, int index, int count)
        {
            var ret = base.Read(buffer, index, count);
            for (int i=0; i<ret; i++)
            {
                int idx = index + i;
                if (!XmlConvert.IsXmlChar(buffer[idx]))
                    buffer[idx] = ' ';
            }
            return ret;
        }
        public override int ReadBlock(char[] buffer, int index, int count)
        {
            var ret = base.ReadBlock(buffer, index, count);
            
            for (int i = 0; i < ret; i++)
            {
                int idx = index + i;
                if (!XmlConvert.IsXmlChar(buffer[idx]))
                    buffer[idx] = ' ';
            }
            return ret;
        }
    }
