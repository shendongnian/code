    public class Logger
    {
        private readonly IBluetoothService _bluetoothService;
        public Logger(IBluetoothService bluetoothService)
        {
            _bluetoothService = bluetoothService;
        }
        public void LogData(string textToLog)
        {
            if (!_bluetoothService.SendData(textToLog))
                throw new ArgumentException("Could not log data");
        }
    }
