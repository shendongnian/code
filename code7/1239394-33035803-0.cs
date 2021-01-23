    using System;
    using System.IO;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            var text = "<foo>\0</foo>";
            var reader = XmlReader.Create(
                 new XmlReplacingReader(new StringReader(text), ' '));
            while (reader.Read())
            {
                Console.WriteLine(reader.NodeType);
            }
        }
    }
    
    public sealed class XmlReplacingReader : TextReader
    {
        private readonly TextReader original;
        private readonly char replacementChar;
        
        public XmlReplacingReader(TextReader original, char replacementChar)
        {
            this.original = original;
            this.replacementChar = replacementChar;
        }
        
        override public int Peek()
        {
            int ret = original.Peek();
            return MaybeReplace(ret);
        }
        
        override public int Read()
        {
            int ret = original.Read();
            return MaybeReplace(ret);        
        }
        
        override public int Read(char[] buffer, int index, int count)
        {
            int ret = original.Read(buffer, index, count);
            for (int i = 0; i < ret; i++)
            {
                buffer[i + index] = MaybeReplace(buffer[i + index]);
            }
            return ret;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                original.Dispose();
            }
        }
        public override void Close()
        {
            original.Close();
        }
        
        private int MaybeReplace(int x)
        {
            return x < 0 ? x : MaybeReplace((char) x);
        }
        
        private char MaybeReplace(char c)
        {
            return (c >= ' ' || c == '\r' || c == '\n' || c == '\t') ? c : replacementChar;
        }
    }
