    public interface B {
        void MethodX();
        void MethodY();
    }
    public static class ExtensionsB {
        public static void MethodZ(this B b) {
            // Common implementations go here
        }
    }
