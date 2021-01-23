    class Sender
    {
      /// <summary>Synchronization primitive</summary>
      private static object sync = new object( );
      /// <summary>Processor wait this long before checking for work (if not nudged)</summary>
      private const int waitTimeOutMilliseconds = 5000;
      /// <summary>What the processor waits on to hear that there are things to do</summary>
      private ManualResetEvent nudge = new ManualResetEvent( false );
      /// <summary>The processor sets this when it's been signaled to stop and message processing is complete</summary>
      private ManualResetEvent done = new ManualResetEvent( false );
      /// <summary>A flag that will be set when the host wants to terminate the message queue processor</summary>
      private bool shutDown = true;
      /// <summary>A queue of messages that need to be sent</summary>
      private Queue<string> queue = new Queue<string>( );
      /// <summary>Puts a message in the queue</summary>
      public void Enqueue( string message )
      {
        lock ( sync )
        {
          if ( shutDown ) throw new InvalidOperationException( "Shutting down - not accepting messages" );
          queue.Enqueue( message );
          nudge.Set( );
        }
      }
      /// <summary>Shuts down without waiting</summary>
      public void Stop( )
      {
        lock ( sync )
        {
          shutDown = true;
          nudge.Set( );
        }
      }
      /// <summary>Starts queue processing</summary>
      public void Start( )
      {
        if ( WaitForShutdown( 5000 ) )
        {
          lock ( sync )
          {
            shutDown = false;
            done.Reset( );
            nudge.Reset( );
            ThreadPool.QueueUserWorkItem( Processor );
          }
        }
        else
        {
          throw new InvalidOperationException( "Couldn't start - that's bad!" );
        }
      }
      /// <summary>Stops accepting messages on the queue, triggers shutdown and waits for the worker thread to complete.</summary>
      /// <param name="millisecondsToWait"></param>
      /// <returns>True if the thread stops in the time specified, false otherwise</returns>
      private bool WaitForShutdown( int millisecondsToWait )
      {
        Stop( );
        lock ( sync )
        {
          if ( shutDown ) return true;
        }
        return done.WaitOne( millisecondsToWait );
      }
      /// <summary>Worker thread method that writes the message</summary>
      private void Processor( object state )
      {
        var processList = new List<string>( );  //--> work we'll take out of the queue
        var cancel = false;  //--> a local representation of shutdown, we'll obtain while under a lock
        while ( true )
        {
          nudge.WaitOne( waitTimeOutMilliseconds );
          lock ( sync )
          {
            cancel = shutDown;
            while ( queue.Any( ) )
            {
              processList.Add( queue.Dequeue( ) );
            }
            nudge.Reset( );
          }
          foreach ( var message in processList )
          {
            try
            {
              // send to service...
            }
            catch ( Exception ex )
            {
              // reconnect or do whatever is appropriate to handle issues...
            }
            if ( cancel ) break;
          }
          processList.Clear( );
          if ( cancel )
          {
            done.Set( );
            return;
          }
        }
      }
    }
