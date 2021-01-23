    public class TextBox : WebObject, IReadable, IWriteable
    {
        private IReadable _readable = new TextReader();
        private IWriteable _writeable = new TextWriter();
        
        public void Read() 
        {
            _readable.Read();
        }
        public void Write() 
        {
            _writable.Write();
        }
    }
    public class Span : WebObject, IReadable
    {
        // Reused class.
        private IReadable _readable = new TextReader();        
        
        public void Read() 
        {
            _readable.Read();
        }
    }
    public class TextReader : IReadable
    {
        public void Read()
        {
            // Reusable implementation
        } 
    }
