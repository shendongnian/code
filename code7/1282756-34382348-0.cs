    public class MyClass {
        public string Name { get; set; }
        public string FaminlyName { get; set; }
        public int Phone { get; set; }
    
        public override bool Equals (object obj) {
             MyClass mobj = obj as MyClass;
             return mobj != null && Object.Equals(this.Name,mobj.Name) && Object.Equals(this.FaminlyName,mobj.FaminlyName) && Object.Equals(this.Phone,mobj.Phone);
        }
    
    }
