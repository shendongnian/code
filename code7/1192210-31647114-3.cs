    public class HttpWebRequestTraceListener : TraceListener
    {
        private readonly RequestTraceCollection _activeTraces = new RequestTraceCollection();
        private readonly Regex _associatedConnection =
            new Regex(@"^\[\d+\] Associating (Connection#\d+) with (HttpWebRequest#\d+)",
                RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.Singleline);
        private readonly Regex _connected = new Regex(@"^\[\d+\] (ConnectStream#\d+) - Sending headers",
            RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.Singleline);
        private readonly Regex _newRequest =
            new Regex(@"^\[\d+\] (HttpWebRequest#\d+)::HttpWebRequest\(([http|https].+)\)",
                RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.Singleline);
        private readonly Regex _requestException = new Regex(@"^\[\d+\] Exception in (HttpWebRequestm#\d+)::",
            RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.Singleline);
        private readonly Regex _responseAssociated =
            new Regex(@"^\[\d+\] Associating (HttpWebRequest#\d+) with (ConnectStream#\d+)",
                RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.Singleline);
        private readonly Regex _responseComplete = new Regex(@"^\[\d+\] Exiting (ConnectStream#\d+)::Close\(\)",
            RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.Singleline);
        private readonly Regex _responseStarted = new Regex(@"^\[\d+\] (Connection#\d+) - Received status line: (.*)",
            RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.Singleline);
        /// <summary>
        ///     When overridden in a derived class, writes the specified
        ///     <paramref name="message" /> to the listener you create in the derived
        ///     class.
        /// </summary>
        /// <param name="message">A message to write.</param>
        public override void Write(string message)
        {
            // Do nothing here
        }
        /// <summary>
        /// Parse the message being logged by System.Net and store relevant event information.
        /// </summary>
        /// <param name="message">A message to write.</param>
        public override void WriteLine(string message)
        {
            var newRequestMatch = _newRequest.Match(message);
            if (newRequestMatch.Success)
            {
                var requestTrace = new RequestTrace(newRequestMatch.Groups[1].Value,
                    new Uri(newRequestMatch.Groups[2].Value));
                requestTrace.StartConnection();
                _activeTraces.Add(requestTrace);
                return;
            }
            var associatedConnectionMatch = _associatedConnection.Match(message);
            if (associatedConnectionMatch.Success)
            {
                var requestTrace = _activeTraces[associatedConnectionMatch.Groups[2].Value];
                _activeTraces.AddAliasKey(requestTrace, associatedConnectionMatch.Groups[1].Value);
                return;
            }
            var connectedMatch = _connected.Match(message);
            if (connectedMatch.Success)
            {
                var requestTrace = _activeTraces[connectedMatch.Groups[1].Value];
                requestTrace.StopConnection();
                requestTrace.StartWaiting();
                return;
            }
            var responseStartedMatch = _responseStarted.Match(message);
            if (responseStartedMatch.Success)
            {
                var requestTrace = _activeTraces[responseStartedMatch.Groups[1].Value];
                requestTrace.StopWaiting();
                requestTrace.StartDownloadTime();
                return;
            }
            var responseAssociatedMatch = _responseAssociated.Match(message);
            if (responseAssociatedMatch.Success)
            {
                var requestTrace = _activeTraces[responseAssociatedMatch.Groups[1].Value];
                _activeTraces.AddAliasKey(requestTrace, responseAssociatedMatch.Groups[2].Value);
                return;
            }
            var responseCompleteMatch = _responseComplete.Match(message);
            if (responseCompleteMatch.Success)
            {
                var requestTrace = _activeTraces[responseCompleteMatch.Groups[1].Value];
                requestTrace.StopDownloadTime();
                _activeTraces.Remove(requestTrace);
                // TODO: At this point the request is done, use this time to store & forward this log entry
                Debug.WriteLine(requestTrace);
                return;
            }
            var faultedMatch = _requestException.Match(message);
            if (faultedMatch.Success)
            {
                var requestTrace = _activeTraces[responseCompleteMatch.Groups[1].Value];
                requestTrace.Faulted();
                _activeTraces.Remove(requestTrace);
                // TODO: At this point the request is done, use this time to store & forward this log entry
                Debug.WriteLine(requestTrace);
            }
        }
    }
