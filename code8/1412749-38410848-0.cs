    // This is your single implementation
    private static void DoLoop(Func<bool> predicate) {
        do {
            //function code
        } while (predicate);
    }
    // These are the wrappers
    public static void MyExtension<T>(this T obj, Func<T, bool> predicate) {
         DoLoop(() => predicate(obj));
    }
    public static void MyExtension<T1, T2>(this T1 obj, T2 OtherObject, Func<T1, T2, bool> predicate) {
         DoLoop(() => predicate(obj, OtherObject));
    }
