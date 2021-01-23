        public string AsyncRequest(string url, int timeout)
        {
            string retval = null;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(timeout);
                try
                {
                    retval = client.GetStringAsync(url).Result;
                    return retval;
                }
                catch
                {
                    AllnetALL3073RemoteSwitch_found = false;
                    return null;
                }
            }
        }
