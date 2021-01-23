    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Connection connection = whereverThisComesFrom();
        if(!Monitor.TryEnter(connection))  return; // another timer is in progress
        try
        {
          for (int i = 0; i < 10; i++)
          {
             connection.startConnection(deviceReceived);
             connection.readFromConnected(deviceReceived);
             connection.endConnection(deviceReceived);
          }
        }
        finally
        {
          Monitor.Exit(connection);
        }
    }
   
