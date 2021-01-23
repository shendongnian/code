    // Receives and processes data
    class Receiver : IDisposable
    {
      public Receiver(WatchDog watchDog);
      public void LoopReceive(); // Tick watch dog on every packet
      public void Dispose();
    }
    
    // Setups timer and periodically checks if receiver is alive.
    // If its not, it asks manager to reconnect and disposes receiver
    class WatchDog : IDisposable
    {
      public WatchDog(ConnectionFactory factory);
      // Setups timer, performs Volatile.Read and if receiver is dead, call dispose on it and ask manager to reconnect.
      public void StartWatching(IDisposable subject);
      public void Tick(); // Volatile.Write
      public void Dispose();
    }
    
    // Can re-connect and create new instances of timer and watchdog
    // Holds instance variable of receiver created
    class ConnectionManager
    {
      public void Connect();
      // disposes watch dog and calls connect
      public void ReConnect(WatchDog watchDog);
    }
