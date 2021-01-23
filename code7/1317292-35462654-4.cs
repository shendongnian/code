    public class Logger
    {
        private readonly object _lock = new object();
        private readonly List<string> _messages = new List<string>();
 
        public void Append(string message)
        {
            // locking ensures that only a single thread can enter this block
            lock (_lock)
            {
                _messages.Add(message);
            }
        }
        // since we are locking this method too, we can be sure that
        // we will join messages into a single string and clear the list
        // without being interrupted (atomically)
        public string Merge()
        {
            lock (_lock)
            {
                // now you are sure you won't lose any data, because
                // it's impossible for other threads to append to _messages
                // between joining and clearing it
                var result = string.Join(Environment.NewLine, _messages);
                _messages.Clear();
                return result;
            }
        }
    }
