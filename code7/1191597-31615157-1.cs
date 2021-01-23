    /* consumer (on your page load) */
    var instance = SomeClass.GetInstance();
    public class SomeClass
    {
        /* prevent consumers from directly instantiating `SomeClass` */
        private SomeClass() {}
        public static SomeClass GetInstance()
        {
            SpecialMethod();
            return new SomeClass();
        };
        private SpecialMethod()
        {
            /* Special stufff ... */
        }
    }
