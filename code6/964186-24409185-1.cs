    public class ModuleData
    {
        public ModuleData(string serialNumber, string fullPath)
        {
            SerialNumber = serialNumber;
            FullPath = fullPath;
        }
        public string SerialNumber { get; private set; }
        public string FullPath { get; private set; }
        public override string ToString()
        {
            return SerialNumber;
        }
    }
