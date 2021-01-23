    public class P2_Service {
        public static P2_Model Execute() {
            var p1Model = P1_Service.Execute();
            return new P2_Model(p1Model);
        }
        public class P2_Model {
            public P2_Model(P1_Model p1Model) {
                Model = p1Model;
            }
            public string Name {
                get { return Model.Name; }
            }
            public P1_Model Model { get; }
        }
    }
