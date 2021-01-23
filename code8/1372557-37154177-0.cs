    public static class Program
    {
        public int static Main()
        {
            AsyncContext.Run(MainImpl);
        }
    
        private async Task MainImpl()
        {
            //Do stuff.
        }
    }
