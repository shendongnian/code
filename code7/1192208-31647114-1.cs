    /// <summary>
    /// Measure and store status and timings of a given Network request.
    /// </summary>
    public class RequestTrace
    {
        private Stopwatch _timer = new Stopwatch();
        /// <summary>
        ///     Initializes a new instance of the <see cref="Object" /> class.
        /// </summary>
        public RequestTrace(string id, Uri url)
        {
            Id = new Stack<string>();
            Id.Push(id);
            Url = url;
            IsFaulted = false;
        }
        /// <summary>
        /// Any Id's that are associated with this request.  Such as
        /// HttpWebRequest, Connection, and associated Streams.
        /// </summary>
        public Stack<string> Id { get; set; }
        /// <summary>
        /// The Url of the request being made.
        /// </summary>
        public Uri Url { get; private set; }
        /// <summary>
        /// Time in ms for setting up the connection.
        /// </summary>
        public long ConnectionSetupTime { get; private set; }
        /// <summary>
        /// Time to first downloaded byte.  Includes sending request headers,
        /// body and server processing time.
        /// </summary>
        public long WaitingTime { get; private set; }
        /// <summary>
        /// Time in ms spent downloading the response.
        /// </summary>
        public long DownloadTime { get; private set; }
        /// <summary>
        /// True if the request encounters an error.
        /// </summary>
        public bool IsFaulted { get; private set; }
        /// <summary>
        /// Call this method when the request begins connecting to the server.
        /// </summary>
        public void StartConnection()
        {
            _timer.Start();
        }
        /// <summary>
        /// Call this method when the requst successfuly connects to the server.  Otherwise, fall <see cref="Faulted"/>.
        /// </summary>
        public void StopConnection()
        {
            _timer.Stop();
            ConnectionSetupTime = _timer.ElapsedMilliseconds;
            _timer.Reset();
        }
        /// <summary>
        /// Call this method after connecting to the server.
        /// </summary>
        public void StartWaiting()
        {
            _timer.Start();
        }
        /// <summary>
        /// Call this method after receiving the first byte of the HTTP server
        /// response.
        /// </summary>
        public void StopWaiting()
        {
            _timer.Stop();
            WaitingTime = _timer.ElapsedMilliseconds;
            _timer.Reset();
        }
        /// <summary>
        /// Call this method after receiving the first byte of the HTTP reponse.
        /// </summary>
        public void StartDownloadTime()
        {
            _timer.Start();
        }
        /// <summary>
        /// Call this method after the response is completely received.
        /// </summary>
        public void StopDownloadTime()
        {
            _timer.Stop();
            DownloadTime = _timer.ElapsedMilliseconds;
            _timer = null;
        }
        /// <summary>
        /// Call this method if an Exception occurs.
        /// </summary>
        public void Faulted()
        {
            DownloadTime = 0;
            WaitingTime = 0;
            ConnectionSetupTime = 0;
            IsFaulted = true;
            if (_timer.IsRunning)
            {
                _timer.Stop();
            }
            _timer = null;
        }
        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return IsFaulted
                ? String.Format("Request to node `{0}` - Exception", Url.DnsSafeHost)
                : String.Format("Request to node `{0}` - Connect: {1}ms - Wait: {2}ms - Download: {3}ms", Url.DnsSafeHost,
                    ConnectionSetupTime, WaitingTime, DownloadTime);
        }
    }
