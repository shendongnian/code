    public static class API
    {
        public static int SendCommand(int aKey, ...)
        {
            try
            {
                PipeClient.StartCommandSendClient(input, aKey);
            }
            catch (TimeoutException)
            {
                // returns error codes based on exceptions
            }
            return 0; 
        }
    }
