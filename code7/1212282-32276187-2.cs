    using System.Collections.Generic;
    using System.Threading;
    public class StreamingChannel
    {
        private readonly List<string> backgroundLinesList;
        private readonly object listLock = new object();
        private Thread streamReaderThread;
        public StreamingChannel()
        {
            streamReaderThread = new Thread(this.ReadWebStream);
            streamReaderThread.Start();
        }
        public List<string> Read()
        {
            if (!streamReaderThread.IsAlive)
            {
                streamReaderThread = new Thread(this.ReadWebStream);
                streamReaderThread.Start();
            }
            List<string> lines = null;
            lock (listLock)
            {
                if (backgroundLinesList != null)
                {
                    lines = backgroundLinesList;
                    backgroundLinesList = null;
                }
            }
            return lines;
        }
        private void ReadWebStream()
        {
            try
            {
                //stuff to set the stream
                HttpWebRequest webRequest;
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), encode);
                while (!responseStream.EndOfStream)
                {
                    var line = responseStream.ReadLine()
                    lock (listLock)
                    {
                        if (backgroundLinesList == null)
                        {
                            backgroundLinesList = new List<string>();
                        }
                        backgroundLinesList.Add(line);
                    }
                }
                log.Debug("Stream closed");
            }
            catch (Exception e)
            {
                log.Debug("WebStream thread failure: " + e + " Stack: " + e.StackTrace);
            }
        }
    }
