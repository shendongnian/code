    private static string _query;
    private static string _scope;
    private static List<ManagementObject> _data;
    private static bool _queryComplete;
    private int _timeout = 300;
    private static readonly object Locker = new Object();
    public List<ManagementObject> CreateRequest(string query, bool eatErrors = false, string scope = null)
        {
            try
            {
                lock (Locker)
                {
                    _queryComplete = false;
                    AscertainObject.ErrorHandler.WriteToLog("Running WMI Query: " + query + "    Timeout:" + _timeout, true);
                    _query = query;
                    _scope = scope;
                    Thread serviceThread = new Thread(RunQuery) { Priority = ThreadPriority.Lowest, IsBackground = true };
                    serviceThread.Start();
                    int timeLeft = _timeout * 10;
                    while (timeLeft > 0)
                    {
                        if (_queryComplete)
                            return _data;
                        timeLeft--;
                        Thread.Sleep(100);
                    }
                    if (eatErrors == false)
                        AscertainObject.ErrorHandler.WriteToLog("WMI query timeout: " + query, true, "");
                    serviceThread.Abort();
                }
            }
            catch (Exception ex)
            {
                if (eatErrors == false)
                    AscertainObject.ErrorHandler.WriteToLog("Error Running WMI Query", true, ex.ToString());
            }
            return null;
        }
        public void SetRequestTimeout(int timeoutSeconds)
        {
            _timeout = timeoutSeconds;
            AscertainObject.ErrorHandler.WriteToLog("WMI query timeout changed to " + timeoutSeconds + " seconds", true);
        }
        private void RunQuery()
        {
            try
            {
                ManagementObjectSearcher searcher = _scope != null ? new ManagementObjectSearcher(_scope, _query) : new ManagementObjectSearcher(_query);
                List<ManagementObject> innerData = searcher.Get().Cast<ManagementObject>().ToList();
                _data = innerData;
            }
            catch (Exception ex)
            {
                AscertainObject.ErrorHandler.WriteToLog("WMI query failed, may have invalid namespace", true, null, true);
                _data = null;
            }
            _queryComplete = true;
        }
