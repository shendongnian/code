    class Example {
        Example instance;
        static void Method() { }
        void Bug() {
            instance.Method();    // CS0176
        }
    }
