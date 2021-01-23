    // subclass WebClient
    public class WebClientWithStats:WebClient
    {
        // appdomain wide storage
        static Dictionary<Uri, long> stats = new Dictionary<Uri, long>();
    
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            // prevent multiple threads changing shared state
            lock(stats)
            {
                long count;
                // do we have thr Uri already, if yes, gets its current count
                if (stats.TryGetValue(request.RequestUri, out count))
                {
                    // add one and update value in dictionary
                    count++;
                    stats[request.RequestUri] = count;
                }
                else
                {
                    // create a new entry with value 1 in the dictionary
                    stats.Add(request.RequestUri, 1);
                }
            }
            return base.GetWebResponse(request);
        }
    
        // make statistics available 
        public static Dictionary<Uri, long> Statistics
        {
            get
            {
                return new Dictionary<Uri, long>(stats);
            }
        }
    }
