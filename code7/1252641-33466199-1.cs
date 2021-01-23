    //Auto property with assignment in constructor
    public class Property
    {
        public string Name { get; set; }
        public List<Building> Buildings {get;set;};
        public Property(){
            Buildings = new List<Building>();
        }
    }
    //Property with backing field
    public class Property
    {
        private List<Building> _buildings = new List<Building>();
        public string Name { get; set; }
        public List<Building> Buildings {get {return _buildings;} set {_buildings = value;}};
    }
