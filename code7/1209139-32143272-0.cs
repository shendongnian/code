    public class LogCollection : ObservableCollection<Log>
    {
        public Post Add(string content)
        {
            Log log = new Log
            {
                Date = DateTime.Now,
                Content = content
            };
            Add(log);
            return log;
        }
    }
