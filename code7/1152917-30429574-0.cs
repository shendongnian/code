    public class Derived : Base
    {
        private static Type4 DEFAULT_T4_VALUE = something;
        private Type3 _t3;
        private Type4 _t4;
    
        // Base class arguments first in the signature
        public Derived(Type1 t1, Type2 t2, Type3 t3, Type4 t4 = null) : Base(t1, t2)
        {
            _t3 = t3;
            if (t4 == null) _t4 = DEFAULT_T4_VALUE;
            else _t4 = t4;
        }
    }
