    public class BufferedStdoutWriter
    {
        public TextWriter Writer;
        public BufferedStdoutWriter() 
        {
            // Use default writer as console output writer
            this.Writer = Console.Out;
        }
        public BufferedStdoutWriter(Stream stream)
        {
            Writer = new StreamWriter(new BufferedStream(stream));
        }
        public void Flush()
        {
            Writer.Flush();
        }
        public void Write<T>(T value)
        {
            Writer.Write(value);
        }
        public void WriteLine<T>(T value)
        {
            Writer.WriteLine(value);
        }
    }
