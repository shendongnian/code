    using System;
    using System.Runtime.InteropServices;
    namespace DllImportTest
    {
        internal static class Program
        {
            private const string TimeFormat12Hour = "0";
            private const string TimeFormat24Hour = "1";
            public static void Main(string[] args)
            {
                var ok = WindowsApi.SetLocaleInfo(0, WindowsApi.LOCALE_ITIME, TimeFormat12Hour);
                if (!ok)
                    throw new ApplicationException(string.Format("Windows API call error {0}.", Marshal.GetLastWin32Error()));
            }
        }
        internal static class WindowsApi
        {
            public const int LOCALE_ITIME = 0x00000023;
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool SetLocaleInfo(uint locale, uint lcType, string lcData);
        }
    }
