    public static class TaskEx
    {
        public static Task Run(Action function)
        {
            return Task.Run(() =>
            {
                try
                {
                    function();
                }
                catch (Exception ex)
                {
                    TraceEx.TraceException(ex);
                    //Dispatch your MessageBox etc.
                }
            });
        }
    }
