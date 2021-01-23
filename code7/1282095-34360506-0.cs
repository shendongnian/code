    public static void Test(String name, Object[] val) {
        Console.WriteLine(2);
        Object dummy = null;
        Test(name, dummy); // uncommenting this line will cause a stackoverflow
        foreach (var v in val) {
            Test(name, v);
        }
    }
