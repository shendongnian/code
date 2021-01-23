    public static void Test(String name, Object[] val) {
        Console.WriteLine(2);
        Object dummy = null;
        Test(name, dummy);
        foreach (var v in val) {
            Test(name, v);
        }
    }
