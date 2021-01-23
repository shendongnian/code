    public class Function
    {
        public void WaitForMessageInQueue([QueueTrigger("webjobsqueue")] string message)
        {
            Console.Out.WriteLine(message);
        }
    }
