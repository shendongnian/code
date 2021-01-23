    public class Test {
        public enum Field {
            A, B, C, D, E..., X, Y, Z
        }
        private readonly int[] data = new int[(int)(Field.Z + 1)];
        public int A {
            get {
                return data[Field.A];
            }
            set {
                data[Field.A] = value;
            }
        }
        //...
        public int Z {
            get {
                return data[Field.Z];
            }
            set {
                data[Field.Z] = value;
            }
        }
        public int this[Field field] {
            set{
                data[field] = value;
            }
    
            get{
                return data[field];
            }
        }
    }
