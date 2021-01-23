    public class TestClass
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
    public static unsafe void TestPointer(object obj, Type parType)
    {
        int size;
        if (parType == typeof(bool))
        {
            size = 1;
        }
        else if (parType == typeof(char))
        {
            size = 2;
        }
        else
        {
            size = Marshal.SizeOf(parType);
        }
        var pointerMethod = obj.GetType().GetMethod("Test");
        byte[] memory = new byte[size];
        fixed (void* ptr = memory)
        {
            pointerMethod.Invoke(obj, new[] { Pointer.Box(ptr, parType.MakePointerType()) });
            object value = Marshal.PtrToStructure((IntPtr)ptr, parType);
            Console.WriteLine(value);
        }
    }
    public static unsafe void TestReference(object obj, Type parType)
    {
        var referenceMethod = obj.GetType().GetMethod("Test2");
        object obj2 = Activator.CreateInstance(parType);
        var pars = new object[] { obj2 };
        referenceMethod.Invoke(obj, pars);
        Console.WriteLine(pars[0]);
    }
    private void Main(string[] args)
    {
        var obj = new TestClass();
        TestPointer(obj, typeof(char));
        TestReference(obj, typeof(char));
    }
