    public class DataObject {
    
        public DataObject() {}
        public DataObject(string[] fields) {   
            // this is an example.  construct a .ctor that is sane for your data.
            // TODO:  Add array bounds checking and data sanity checks
            this.ID = fields[0];
            this.Field1 = fields[1];
            this.Field2 = fields[2];
        }
    
        public string ID {get; set;}
    
        public string Field1 {get; set;}
    
        public string Field2 {get; set;}
    }
