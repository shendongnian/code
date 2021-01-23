    static class WebServer {
        private static readonly HttpListener Listener = new HttpListener { Prefixes = { "http://*/" } };
        private static bool _keepGoing = true;
        private static Task _mainLoop;
        
        public static void StartWebServer() {
            if (_mainLoop != null && !_mainLoop.IsCompleted) return;
            _mainLoop = MainLoop();
        }
        
        public static void StopWebServer() {
            _keepGoing = false;
            lock (Listener) {
                //Use a lock so we don't kill a request that's currently being processed
                Listener.Stop();
            }
            try {
                _mainLoop.Wait();
            } catch { /* je ne care pas */ }
        }
        
        private static async Task MainLoop() {
            Listener.Start();
            while (_keepGoing) {
                try {
                    var context = await Listener.GetContextAsync();
                    lock (Listener) {
                        if (_keepGoing) ProcessRequest(context);
                    }
                } catch (Exception e) {
                    if (e is HttpListenerException) return; //this gets thrown when the listener is stopped
                    //handle bad error here
                }
            }
        }
        
        private static void ProcessRequest(HttpListenerContext context) {
            string inputData;
            using (var body = context.Request.InputStream) {
                using (var reader = new StreamReader(body, context.Request.ContentEncoding)) {
                    inputData = reader.ReadToEnd();
                }
            }
            //inputData now has the raw data that was sent
            //if you need to see headers, they'll be in context.Request.Headers
            
            //now you can make the outbound request with authentication here
            
            //send result back to caller using context.Response
        }
    }
