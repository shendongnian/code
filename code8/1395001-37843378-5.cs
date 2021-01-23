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
                SomeList = new int[288],
                PathToData = "C:\\some\\path\\to\\data"
            };            
            var listData = new int[] { 0, 12, 33, 67, 93 };
            Array.Copy(listData, dllInput.SomeList, listData.Length);
        }
