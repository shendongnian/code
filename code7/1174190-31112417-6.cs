    private static void ProcessResponse(string url, Action<WebResponse> action) 
    {
        for (int i=1; i <= NumberOfRetries; ++i) 
        {
            try 
            {
                var request = WebRequest.Create(line);
                
                using (var response = request.GetResponse()) 
                {
                    action(response);
                }
            }
            catch (Exception e) 
            {
                if (i == NumberOfRetries)
                    throw;
    
                Thread.Sleep(DelayOnRetry);
            }
        }
    }
    
    private const int NumberOfRetries = 3;
    private const int DelayOnRetry = 1000;
