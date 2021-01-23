    [TimeoutFilter( 10000 )]
    public string Get( )
    {
        Thread.Sleep( 5000 );
        return "Results";
    }
