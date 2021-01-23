    public class BufferedStdoutWriter
    {
        // Use default writer as console output writer
        public static readonly TextWriter Writer = Console.Out;
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
