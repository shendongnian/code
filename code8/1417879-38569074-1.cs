    [Profiling( ApplyToStateMachine = true )]
    public async Task TestProfiling()
    {
        await Task.Delay( 1000 );
        Thread.Sleep( 1000 );
    }
