    public interface IBluetoothService
    {
        object GetData();
        bool SendData(object request);
    }
    public class BluetoothAPI : IBluetoothService
    {
        public object GetData()
        {
            // API logic to get data.
            return new object();
        }
        public bool SendData(object request)
        {
            // API logic to send data.
            return false;
        }
    }
