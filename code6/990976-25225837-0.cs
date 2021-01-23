        public static void SubmitUrl(string url)
        {
            Task.Factory.StartNew(() => SubmitUrlPrivate(url));
        }
        private static void SubmitUrlPrivate(string url)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    Logger.Log(string.Format("Start Invoking URL: {0}", url));
                    using (webClient.OpenRead(url))
                    {
                        Logger.Log(string.Format("End Invoking URL: {0}", url));
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status != WebExceptionStatus.Timeout)
                    {
                        Logger.Log(string.Format("Exception Invoking URL: {0} \n {1}", url, ex.ToString()));
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(string.Format("Exception Invoking URL: {0} \n {1}", url, ex.ToString()));
                    throw;
                }
            }
        }
