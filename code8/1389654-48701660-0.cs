    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    class IndirectString
    {
        [DllImport("shlwapi.dll", BestFitMapping = false, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false, ThrowOnUnmappableChar = true)]
        public static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);
    
        public string ExtractNormalPath(string indirectString)
        {
            StringBuilder outBuff = new StringBuilder(1024);
            int result = SHLoadIndirectString(indirectString, outBuff, outBuff.Capacity, IntPtr.Zero);
    
            return outBuff.ToString();
        }
    }
