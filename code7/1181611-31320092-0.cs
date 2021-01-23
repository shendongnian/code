    // Hand-off through a BufferBlock<T>
    private static BufferBlock<int> m_buffer = new BufferBlock<int>();
    
    // Producer
    private static void Producer()
    {
        while(true)
        {
            int item = Produce();
            // storing the messages in FIFO queue
            m_buffer.Post(item);
        }
    }
    
    // Consumer
    private static async Task Consumer()
    {
        while(true)
        {
            int item = await m_buffer.ReceiveAsync();
            Process(item);
        }
    }
    
    // Main
    public static void Main()
    {
        var p = Task.Factory.StartNew(Producer);
        var c = Consumer();
        Task.WaitAll(p,c);
    }
