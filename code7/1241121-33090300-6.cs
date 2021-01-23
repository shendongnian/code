    public class ThirdParty
    {
        public static void DoWork()
        {
            new Thread(() => Thread.Sleep(10000)) { IsBackground = true }.Start();
        }
    }
