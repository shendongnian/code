    public class ClassName : NotifyChangements
    {
        private YourType selectedDeviceType;
        public YourType SelectedDeviceType
        {
            get { return selectedDeviceType; }
            set
            {
                selectedDeviceType = value;
                NotifyPropertyChanged("SelectedDeviceType");
                MAJDeviceName();
            }
        }
        
        // Later in code.
        public void MAJDeviceName()
        {
            // Add code here that fill the DeviceNameList according to the SelectedDeviceType.
        }
    }
