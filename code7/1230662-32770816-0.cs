    public class Worker
    {
        private CancellationTokenSource m_CancellationTokenSource;
        public void Start()
        {
            m_CancellationTokenSource = new CancellationTokenSource();
            var token = m_CancellationTokenSource.Token;
            Task.Factory.StartNew(() =>
            {
                
                //Prepare the things you need to do before the loop, like opening the files and devices
                while (!token.IsCancellationRequested)
                {
                    //Do something here like continuously reading and writing
                }
            }, token)
            .ContinueWith(t =>
            {
                //This will run after stopping, close files and devices here
            });
        }
        public void Stop()
        {
            m_CancellationTokenSource.Cancel();
        }
    }
