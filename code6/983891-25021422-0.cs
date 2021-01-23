    public static class AssemblyExtension
    {
        public static void HelperMethod1(this Assembly asm)
        {
            Console.WriteLine(asm.ToString());
        }
    }
