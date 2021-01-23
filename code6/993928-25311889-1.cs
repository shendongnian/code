    [StructLayout(LayoutKind.Sequential)]
    public struct Demo
    {
        public double X;
        public double Y;
    }
    private static void Main()
    {
        Demo[] array = new Demo[2];
        array[0] = new Demo { X = 5.6, Y = 6.6 };
        array[1] = new Demo { X = 7.6, Y = 8.6 };
        byte[] bytes = ToByteArray(array);
        Demo[] array2 = FromByteArray<Demo>(bytes);
    }
