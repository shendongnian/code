    [DebuggerDisplay("{VehicleName}")]
    public class Vehicles : IComparable<Vehicles>, INotifyPropertyChanged
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                if (id != value) { id = value; NotifyPropertyChanged(); }
            }
        }
        private string vehicleName;
        public string VehicleName
        {
            get { return vehicleName; }
            set
            {
                if (vehicleName != value) { vehicleName = value; NotifyPropertyChanged(); }
            }
        }
        public override string ToString()
        {
            return VehicleName;
        }
        [IgnoreDataMember]
        public UpdateState UpdateState { get; set; }
        ....
