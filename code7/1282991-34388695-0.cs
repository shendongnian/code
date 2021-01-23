    public class Bar<T1, T2> {
        public void Method(T1 t) {
            Console.WriteLine("FirstMethod");
        }
        public void Method(T2 t) {
            Console.WriteLine("SecondMethod");
        }
    }
    public static void CallFirstMethod<T1, T2>(Bar<T1, T2> bar, T1 t) {
        bar.Method(t);
    }
    public static void CallSecondMethod<T1, T2>(Bar<T1, T2> bar, T2 t) {
        bar.Method(t);
    }
    public static void Test() {
        var bar = new Bar<int, int>();
        CallFirstMethod(bar, 5);
        CallSecondMethod(bar, 6);
    }
