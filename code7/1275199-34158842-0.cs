    public class ProgramEntry {
    
        public long Id;
        public string Name;
        public long VM;
        public long Vm;
    
        public ProgramEntry (long id, string name, long vM, long vm) {
            Id = id;
            Name = name;
            VM = vM;
            Vm = vm;
        }
        public override string ToString () {
            return this.Id+":"+this.Name+"("+this.VM+"."+this.Vm+")";
        }
    
    }
