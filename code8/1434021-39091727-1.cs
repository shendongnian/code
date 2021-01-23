    public class Functions
    {
        private static TestService _testService;
        public Functions(TestService testService)
        {
            _testService = testService;
        }
        public void ProcessStuff([QueueTrigger("my-queue")] string userId)
        {
            try
            {
                Console.WriteLine("ProcessStuff is invoked with value={0}", userId);
                string result = _testService.DoStuff(userId);
                Console.WriteLine("ProcessStuff return the result:\r\n{0}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("ProcessStuff executed with errors.\r\n{0}\r\n{1}", e.Message, e.StackTrace);
            }
        }
    }
