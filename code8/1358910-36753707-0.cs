    public class TreeViewItemModel : NotifyObject
    {
        private string _name;
        private Guid _iD;
        private string _parentName;
        private Guid _parentId;
        private string _parentDeviceName;
        private ObservableCollection<TreeViewItemModel> _children = new ObservableCollection<TreeViewItemModel>();
        
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public Guid ParentId
        {
            get { return _parentId; }
            set { SetProperty(ref _parentId, value); }
        }
        public string ParentDeviceName
        {
            get { return _parentDeviceName; }
            set { SetProperty(ref _parentDeviceName, value); }
        }
        public string ParentName
        {
            get { return _parentName; }
            set { SetProperty(ref _parentName, value); }
        }
        public Guid Id
        {
            get { return _iD; }
            set { SetProperty(ref _iD, value); }
        }
        public ObservableCollection<TreeViewItemModel> Children
        {
            get { return _children; }
            set { SetProperty(ref _children, value); }
        }
                
        public TreeViewItemModel(object thing)
        {
            //GetDevices();
            if (thing.GetType() == typeof (Space))
            {
                var space = (Space)thing;
                var parentName = string.Empty;
                if (space.Parent != null)
                {
                    parentName = space.Parent.Name;
                }
                Name = space.Name;
                ParentName = parentName;
                Id = space.Id;
                Children = new ObservableCollection<TreeViewItemModel>(space.Children.Select(s => new TreeViewItemModel(s)).Union(space.Devices.Select(d => new TreeViewItemModel(d)).Union(space.Sensors.Select(sensor => new TreeViewItemModel(sensor)))));
            }
            else if (thing.GetType() == typeof (Device))
            {
                var device = (Device) thing;
                var parentName = device.Space.Name;
                Name = device.Name;
                ParentName = parentName;
                Id = device.Id;
                Children = new ObservableCollection<TreeViewItemModel>(device.Sensors.Select(s => new TreeViewItemModel(s)));
            }
            else if (thing.GetType() == typeof(Sensor))
            {
                var sensor = (Sensor) thing;
                var space = sensor.Space.Name ?? string.Empty;
                //var device = Devices.First(d => d.Id == sensor.DeviceId);
                var device = sensor.Device;
                ParentName = device == null ? "No Matching Device" : device.Name;
                Name = sensor.Id.ToString();
                Id = sensor.Id;
                ParentName = space;
                
                Children = null;
            }
            
        }
