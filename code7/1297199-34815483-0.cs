    public class TestThread : MonoBehaviour
    {
        private readonly WaitCallback _callback;
    
        public TestThread()
        {
            _callback = new WaitCallback(DummyMethod);
        }
    
        public void Update()
        {
            if (Time.frameCount%10 == 0)
                ThreadPool.QueueUserWorkItem(_callback);
        }
    
        public void DummyMethod(object meaningless)
        {
        }
    }
