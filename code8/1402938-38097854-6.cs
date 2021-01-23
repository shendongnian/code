    public class TestDispose : IDisposable
    {
        private IntPtr m_Chunk;
        private int m_Counter;
        private static int s_Counter;
        public TestDispose()
        {
            m_Counter = s_Counter++;
            // get 256 MB
            m_Chunk = Marshal.AllocHGlobal(1024 * 1024 * 256);
            Debug.WriteLine("TestDispose {0} constructor called.", m_Counter);
        }
        public void Dispose()
        {
            Debug.WriteLine("TestDispose {0} dispose called.", m_Counter);
            Marshal.FreeHGlobal(m_Chunk);
            m_Chunk = IntPtr.Zero;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            for(var i = 0; i < 1000; i ++)
            {
                var foo = new TestDispose();
            }
            Console.WriteLine("Press any key to end...");
            Console.In.ReadLine();
        }
    }
