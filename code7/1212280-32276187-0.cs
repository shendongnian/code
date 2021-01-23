    using System.Collections.Concurrent;
    using System.Threading;
    public class StreamingChannel
    {
        private readonly ConcurrentQueue<string> linesQueue = new ConcurrentQueue<string>();
        private Thread streamReaderThread;
        public StreamingChannel()
        {
            streamReaderThread = new Thread(this.ReadWebStream);
        }
        public string Read()
        {
            if (!streamReaderThread.IsAlive)
            {
                streamReaderThread = new Thread(this.ReadWebStream);
            }
            string line = null;
            if (!linesQueue.IsEmpty)
            {
                linesQueue.TryDequeue(out line);
                // Alternately, consider returning all buffered lines in a List<string>.
            }
            return line;
        }
        private void ReadWebStream()
        {
            try
            {
                //stuff to set the stream
                HttpWebRequest webRequest;
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                var responseStream = new StreamReader(webResponse.GetResponseStream(), encode);
                while (!responseStream.EndOfStream)
                {
                    linesQueue.Enqueue(responseStream.ReadLine());
                }
                log.Debug("Stream closed");
            }
            catch (Exception e)
            {
                log.Debug("WebStream thread failure: " + e + " Stack: " + e.StackTrace);
            }
        }
    }
