    class TimedSingleton
    {
        // have a dictonary to hold the seconds
        // and the instance so we can lookup
        private static Dictionary<int, TimedSingleton> AddedPositions = new Dictionary<int, TimedSingleton>();
    
        private static DateTime _startTime = DateTime.Now;
    
        protected TimedSingleton()
        {
        }
    
        public static TimedSingleton Instance()
        {
            // divide by 5
            int index = (int)DateTime.Now.Subtract(_startTime).TotalSeconds / 5;
            Debug.WriteLine(index);
    
            // 
            TimedSingleton result;
            // if you're going to multhreed this
            lock(AddedPositions)
            {
                // try to get the index seconds ...
                if (!AddedPositions.TryGetValue(index,out result))
                {
                    // not happened
                    Debug.WriteLine("Created new instance");
                    result = new TimedSingleton();
                    // store it for later
                    AddedPositions.Add(index, result);
                }
                else
                {
                    // result has now a previous instance
                    Debug.WriteLine("from cache");
                }
            }
            return result;
        }
    }
