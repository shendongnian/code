    public static void testB()
    {
        StackTrace stackTrace = new StackTrace();
        Type callingType = stackTrace.GetFrame(1).GetMethod().DeclaringType;
        FieldInfo field = callingType.GetField("Aa", BindingFlags.Public | BindingFlags.Static);
        string Bb = (string) field.GetValue(null);
        Console.WriteLine(Bb);
    }
