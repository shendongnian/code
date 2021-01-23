    Device device = ...
    using(var connection = device.CreateConnection())
    {
        var results = connection.Read();
    }
    public abstract class Connection : IDisposable
    {
        public object Read();
    }
    public class Device
    {
        private class DeviceConnection : Connection 
        {
            private Device Parent { get; set; }
            
            void Dispose()
            {
                Parent.StopConnection();
            }
            public object Read() 
            {
                return Device.readFromConnected();
            }
        }        
        private int _connections = 0;
        public Connection CreateConnection()
        {
           // start connection
           if(Interlocked.Increment(ref _connections) == 1)
           {
              //do work to connect.
           }
           return new DeviceConnection { Parent = this };
        }
        private bool StopConnection()
        {
           // End connection
           if(Interlocked.Decrement(ref _connections) == 0)
           {
              //do work to disconnect.
           }
        }
         
        private object readFromConnected()
        {
            //Device is guaranteed to be connected now!
        }
    }
