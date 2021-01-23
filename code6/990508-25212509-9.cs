    public class Class1: Module<BasicData> {
        public Class1(BasicData val) {
            base.value = val;
        }
    
        public override void Update() {
            //Do something here
        }
    
        public override BasicData Value {
            get {
                return base.value;
            }
            set {
                base.value = value;
            }
        }
    }
