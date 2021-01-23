    public abstract class WebObjectReadWrite : WebObject, IReadable, IWritable
    {
        // Could be made virtual is some subclasses need to overwrite default implementation.
        public void Read() 
        {
            // Implementation
        }
        // Could be made virtual is some subclasses need to overwrite default implementation.
        public void Write() 
        {
            // Implementation
        }
    }
    public class TextBox : WebObjectReadWrite
    {
    }
