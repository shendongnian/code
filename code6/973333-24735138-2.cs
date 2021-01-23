    public static void ObjectToString(out string buffer, Comarea comarea)
    {
        int size = 0;
        IntPtr pBuf = IntPtr.Zero;
    
        try
        {
            size = Marshal.SizeOf(comarea);
            pBuf = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(comarea, pBuf, false);
            buffer = Marshal.PtrToStringAuto(pBuf, size).Substring(0, size/2); // Answer
        }
        catch
        {
            throw;
        }
        finally
        {
            Marshal.FreeHGlobal(pBuf);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Comarea
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        private char[] status;
    
        public string Status
        {
            get
            {
                return new string(status);
            }
    
            set
            {
                status = value.ToFixedCharArray(1);
            }
        }
    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        private char[] operationName;
    
        public string OperationName
        {
            get
            {
                return new string(operationName);
            }
    
            set
            {
                operationName = value.ToFixedCharArray(5);
            }
        }
    }
    public static class FormatterExtensions
    {
        [DebuggerStepThrough]
        public static char[] ToFixedCharArray(this string inputString, int arrayLength)
        {
            char[] outputArray = new char[arrayLength];
            char[] inputArray = inputString.ToSafeTrim().ToCharArray();
    
            if (inputArray.Length == arrayLength)
            {
                return inputArray;
            }
            else
            {
                int i = 0;
    
                while (i < arrayLength)
                {
                    if (i < inputArray.Length)
                    {
                        outputArray[i] = inputArray[i];
                    }
                    else
                    {
                        break;
                    }
    
                    i++;
                }
    
                return outputArray;
            }
        }
    }
