    public class A {
        public void F() {
            //  Compiler says "The name 'M' does not exist in current context."
            //  Current context is A. There is no M in A. M who? M in B or M in C?
            //  You must specify what M you mean! The compiler plays no guessing games.
            M();
            //  This will compile.
            //  Now the compiler knows where M lives and can find him.
            B.M();
        }
    }
    public class B {
        public static void M() {
            //  Do stuff
        }
    }
    public class C {
        public static void M() {
            //  Do TOTALLY DIFFERENT stuff
        }
    }
