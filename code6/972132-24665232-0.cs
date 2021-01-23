    public class SomeBusinessObject : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private int property1;
        public int Property1
        {
            get { return property1; }
            set { property1 = value; OnPropertyChanged("Property1"); }
        }
        private string property2;
        public int Property2
        {
            get { return property2; }
            set { property2 = value; OnPropertyChanged("Property2"); }
        }
        //... Other properties
        public bool IsModified { get; set; }
        public bool IsPersistable { get; set; }
        public SomeBusinessObject PersistedState { get; private set; }
        
        public SomeBusinessObject(int id, int p1, string p2, savePersistedState = false)
        {
            Id = id;
            Property1 = p1;
            Property2 = p2;
            //Set other properties
            if (savePersistedState) PersistedState = new SomeBusinessObject(id, p1, p2)
        }
    }
