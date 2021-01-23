    public class DeviceDatabaseViewModel
    {
        public ObservableCollection<Device> AllDevices
        {
            get; set;
        }
        public DeviceDatabaseViewModel()
        {
            AllDevices = new ObservableCollection<Device>();
            AllDevices.Add(new Device { Category = 'Computer', CategoryId = 1 }, new Device { Category = 'Tablet', CategoryId = 2 });
        }
    }
