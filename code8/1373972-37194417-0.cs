    public interface IBluetoothService
    {
        object GetData();
        bool SendData(object request);
    }
    public class BluetoothAPI : IBluetoothService
    {
        public object GetData()
        {
            return new object();
        }
        public bool SendData(object request)
        {
            return false;
        }
    }
