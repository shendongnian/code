    public class Connection
    {
        private int _connections = 0;
        internal bool startConnection(Device dev)
        {
           // start connection
           if(Interlocked.Increment(ref _connections) == 1)
           {
              //do work to connect.
           }
        }
        internal bool endConnection(Device dev)
        {
           // End connection
           if(Interlocked.Decrement(ref _connections) == 0)
           {
              //do work to disconnect.
           }
        }
        private void readFromConnected(Device dev)
        {
            if(_connections > 0)
            {
                // read values from connected device
            }
        }
    }
