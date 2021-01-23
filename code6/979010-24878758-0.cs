    class TestCollectTimer
    {
        public static void Test()
        {
        for (int index_A = 0; index_A < 100000; index_A++)
        {
            using(MyTimerData mtd = new MyTimerData())
            {
               //do your stuff here
            }
            
        }
        GC.Collect();
        Form f = new Form();
        f.ShowDialog();
    }
    }
    class MyTimerData : IDisposable
    {
    public System.Threading.Timer m_timer;
    public MyTimerData()
    {
        this.m_timer = new System.Threading.Timer(
            new System.Threading.TimerCallback(this.TimerCall),
            null,
            System.Threading.Timeout.Infinite,
            System.Threading.Timeout.Infinite);
    }
    public void TimerCall(object o) { }
    public void Dispose()
    {
        Dispose(true);
    }
    protected void Dispose(bool disposing)
    {
       m_timer.Dispose();
       GC.SuppressFinalize(this);
    }
    }
