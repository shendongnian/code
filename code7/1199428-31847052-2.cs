    public class P1_Model {
        public string Name {
            get { return "1"; }
        }
    }
    public class P1_Service {
        public static P1_Model Execute() {
            return new P1_Model();
        }
    }
