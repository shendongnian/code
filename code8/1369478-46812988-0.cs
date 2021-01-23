    public class SshCommandStreamReader : IDisposable
    {
        private readonly Stream stream;
        private readonly MemoryStream intermediateStream;
        private readonly StreamReader reader;
        public SshCommandOutputReader(Stream stream)
        {
            this.stream = stream;
            this.intermediateStream = new MemoryStream();
            this.reader = new StreamReader(intermediateStream, Encoding.UTF8);
        }
        private int FlushToIntermediateStream()
        {
            var length = stream.Length;
            if (length == 0)
            {
                return 0;
            }
            // IMPORTANT: Do NOT read with a count higher than the stream length (which is typical of reading
            // from streams). The streams for SshCommand are implemented by PipeStream (an internal class to
            // SSH.NET). Reading more than the current length causes it to *block* until data is available.
            // If the stream is flushed when reading, it does not block. It is not reliable to flush and then
            // read because there is a possible race condition where a write might occur between flushing and
            // reading (writing resets the flag that it was flushed). The only reliable solution to prevent
            // blocking when reading is to always read the current length rather than an arbitrary buffer size.
            var intermediateOutputBuffer = new byte[length];
            var bytesRead = stream.Read(intermediateOutputBuffer, 0, intermediateOutputBuffer.Length);
            intermediateStream.Write(intermediateOutputBuffer, 0, bytesRead);
            return bytesRead;
        }
        public string Read()
        {
            var bytesFlushed = FlushToIntermediateStream();
            // Allow reading the newly flushed bytes.
            intermediateStream.Position -= bytesFlushed;
            // Minor optimization since this may be called in a tight loop.
            if (intermediateStream.Position == intermediateStream.Length)
            {
                return null;
            }
            else
            {
                var result = reader.ReadToEnd();
                return result;
            }
        }
        public void Dispose()
        {
            reader.Dispose();
            intermediateStream.Dispose();
        }
    }
