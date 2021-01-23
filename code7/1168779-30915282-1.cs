    public class TestBool
    {
        unsafe public void Test(bool* pointer)
        {
            *pointer = true;
        }
        public void Test2(ref bool reference)
        {
            reference = true;
        }
    }
    public class TestChar
    {
        unsafe public void Test(char* pointer)
        {
            *pointer = 'A';
        }
        public void Test2(ref char reference)
        {
            reference = 'B';
        }
    }
    public static void TestPointer(object obj, Type parType)
    {
        var pointerMethod = obj.GetType().GetMethod("Test");
        Type parType2;
        // Non-blittable types aren't directly supported. 
        // See https://msdn.microsoft.com/en-us/library/75dwhxf7.aspx
        // We cheat a little.
        if (parType == typeof(bool))
        {
            parType2 = typeof(byte);
        }
        else if (parType == typeof(char))
        {
            parType2 = typeof(short);
        }
        else if (parType.IsEnum)
        {
            parType2 = Enum.GetUnderlyingType(parType);
        }
        else
        {
            parType2 = parType;
        }
        object obj2 = Activator.CreateInstance(parType2);
        GCHandle handle = default(GCHandle);
        try
        {
            handle = GCHandle.Alloc(obj2, GCHandleType.Pinned);
            pointerMethod.Invoke(obj, new object[] { handle.AddrOfPinnedObject() });
        }
        finally
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }
        if (parType == typeof(bool))
        {
            obj2 = (byte)obj2 != 0;
        }
        else if (parType == typeof(char))
        {
            obj2 = (char)(short)obj2;
        }
        else if (parType.IsEnum)
        {
            obj2 = Enum.ToObject(parType, obj2);
        }
        Console.WriteLine(obj2);
    }
    public static void TestReference(object obj, Type parType)
    {
        var referenceMethod = obj.GetType().GetMethod("Test2");
        object obj2 = Activator.CreateInstance(parType);
        var pars = new object[] { obj2 };
        referenceMethod.Invoke(obj, pars);
        Console.WriteLine(pars[0]);
    }
    private static void Main(string[] args)
    {
        {
            var obj = new TestBool();
            TestPointer(obj, typeof(bool));
            TestReference(obj, typeof(bool));
        }
        {
            var obj = new TestChar();
            TestPointer(obj, typeof(char));
            TestReference(obj, typeof(char));
        }
    }
