    private static BufferBlock<int> m_buffer = new BufferBlock<int>>(
        new DataflowBlockOptions { BoundedCapacity = 10, MaxDegreeOfParallelism = 4 });
    
    // Producer
    private static async void Producer()
    {
        while(true)
        {
            await m_buffer.SendAsync(Produce());
        }
    }
    
    // Consumer
    private static async Task Consumer()
    {
        while(true)
        {
            Process(await m_buffer.ReceiveAsync());
        }
    }
