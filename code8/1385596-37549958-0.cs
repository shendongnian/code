        static void GetDataFromApi(DataRow row)
        {
            var requestKey = (string)row["Url"];
            if (_runningRequests.TryAdd(requestKey, true))
            {
                try
                {
                    //send web request
                }
                finally
                {
                    bool alreadyRunning;
                    _runningRequests.TryRemove(requestKey, out alreadyRunning);
                }
            }
        }
