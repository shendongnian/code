    public static void Main()
    {
        // ...
        if (DivisibleByAllUpTo20(i))
        {
            //do action x
        }
        // ...
    }
    private static bool DivisibleByAllUpTo20(int i)
    {
        return (i % 1 == 0) && (i % 2 == 0) && (...) && (i % 20 == 0);
    }
