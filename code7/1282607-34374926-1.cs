    public class Main {
        public static void Test(Car test) {
            ... // This method will be called by Main.Test(this) of a Car
        }
        public static void Test(Bus test) {
            ... // This method will be called by Main.Test(this) of a Bus
        }
        public static void Test(Rv test) {
            ... // This method will be called by Main.Test(this) of an Rv
        }
    }
