    /* consumer (on your page load) */
    var instance = SomeClass.GetInstance();
    public class SomeClass
    {
        /* prevent consumers from directly instantiating `SomeClass` */
        private SomeClass() {}
        public static SomeClass GetInstance()
        {
            var instance = new SomeClass();
            instance.SpecialMethod();
            return instance;
        };
        private void SpecialMethod()
        {
            /* Special stufff ... */
        }
    }
