    public struct Inner {
        public static void Init(out Inner value,int _f1,int _f2) {
            value.f1=_f1;
            value.f2=_f2;
        }
        public int f1;
        public int f2;
    }
    public struct Outer {
        public static void Init(out Outer value,int _f1,int _f2,int _z) {
            Inner.Init(out value.f,_f1,_f2);
            value.z=_z;
        }
        public int z;
        public Inner f;
    }
    public class HelloWorld {
        static public void Main() {
            Outer someVar;
            Outer.Init(out someVar,4,5,6);
