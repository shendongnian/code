    public class MainViewModel : PropertyChangedBase
    {
        // ...
        public MainViewModel() 
        {
          ComPorts = new ObservableCollection<string>();
        }
        public void RefreshCOM()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach(var port in ports)
            {
               ComPorts.Add(port);
            }
        }
        
        public ObservableCollection<string> ComPorts {get; private set;}
        // ...
    }
