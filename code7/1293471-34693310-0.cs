    public class Worker
    {
        public void DoWork()
        {
            while (true)
            {
                alive(); // this sends an http request to my server
                Thread.Sleep(5000); // sleep for 5 seconds avoiding computer overcharge
            }
        }
    }
