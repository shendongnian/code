        public class BackgroundResult
        {
            public string Response; // for simplicity, just use a public field for this example--for a real implementation, public fields are probably bad
        }
        class BackgroundQuery
        {
            Thread _thread;
            public BackgroundQuery()
            {
                _thread = new Thread(new ThreadStart(BackgroundThread));
                _thread.IsBackground = true; // allow the application to shut down without errors even while this thread is still running
                _thread.Name = "Background Query Thread";
                _thread.Start();
            }
            private void BackgroundThread()
            {
                try
                {
                    while (true)
                    {
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://example.com/samplepath?query=query");
                            request.Method = "GET";
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                                {
                                    // get what I need here (just the entire contents as a string for this example)
                                    string result = reader.ReadToEnd();
                                    // put it into the results
                                    BackgroundResult backgroundResult = new BackgroundResult { Response = result };
                                    System.Threading.Interlocked.Exchange(ref _BackgroundResult, backgroundResult);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // the request failed--cath here and notify us somehow, but keep looping
                            System.Diagnostics.Trace.WriteLine("Exception doing background web request:" + ex.ToString());
                        }
                        // wait for five minutes before we query again.  Note that this is five minutes between the END of one request and the start of another--if you want 5 minutes between the START of each request, this will need to change a little.
                        System.Threading.Thread.Sleep(5 * 60 * 1000);
                    }
                }
                catch (Exception ex)
                {
                    // we need to get notified of this error here somehow by logging it or something...
                    System.Diagnostics.Trace.WriteLine("Error in BackgroundQuery.BackgroundThread:" + ex.ToString());
                }
            }
        }
        private static BackgroundQuery _BackgroundQuerier;  // set only during application startup
        private static BackgroundResult _BackgroundResult;  // interlocked
        /// <summary>
        /// Gets the background result.  If <see cref="_BackgroundResult"/> is used directly, its contents could change while we're using it--not so with what is returned from this function, unless you call it multiple times without keeping the result.
        /// </summary>
        /// <returns>The <see cref="BackgroundResult"/> from the last query.</returns>
        private static BackgroundResult GetBackgroundResult()
        {
            return _BackgroundResult;
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            // other initialization here...
            _BackgroundQuerier = new BackgroundQuery();
            // other initialization here...
        }
