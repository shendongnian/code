        [StructLayout(LayoutKind.Sequential)]
        public struct MyDllInput
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 288)]
            public int[] SomeList;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] PathToData;
        }
        public static void Main()
        {
            MyDllInput dllInput = new MyDllInput()
            {
                SomeList = new int[288],
                PathToData = new byte[256]
            };
            var listData = new int[] { 0, 12, 33, 67, 93 };
            Array.Copy(listData, dllInput.SomeList, listData.Length);
            var pathToDataBytes = Encoding.UTF8.GetBytes("C:\\some\\path\\to\\data");
            Array.Copy(pathToDataBytes, dllInput.PathToData, pathToDataBytes.Length);
        }
