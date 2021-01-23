    public class ViewModel : Item
    {
        public int Added {get;set;}
        public int Removed {get;set;}
        public int Existing {get;set;}
        public ViewModel(Item i) {
            this.id = i.id;
            this.code = i.code;
            this.Added = i.operations.Where(o => o.operationTypeID == 10).Count;
            this.Removed = i.operations.Where(o => o.operationTypeID == 20).Count;
            this.Existing = i.iChild.Count;
       }
    }
