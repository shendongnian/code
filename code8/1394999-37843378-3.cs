        [StructLayout(LayoutKind.Sequential)]
        public struct MyDllInput
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 288)]
            public int[] SomeList;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst =256)]
            public String PathToData;
        }
        public static void Main()
        {
            MyDllInput dllInput = new MyDllInput()
            {
                SomeList = new int[] { 0, 12, 33, 67, 93 },
                PathToData = "C:\\some\\path\\to\\data"
            };            
        }
