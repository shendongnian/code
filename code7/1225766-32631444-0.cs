    public class DataVector : INotifyPropertyChange
    {
        public DataTable OriginationDataTable { get; set; }
        public int OrininationRow { get; set; }
    
        // Mirror the properties
        public string Name { get {} { _Name = value; NotifyChange("Name"); }
        // CTORs which help create this object
        public DataVector(DataTable dt, int originatingRow) { ... } 
       ....
    }
