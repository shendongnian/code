    using Microsoft.Win32;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using Windows.ApplicationModel;
    
    public class PackageUtil
    {
        [DllImport("shlwapi.dll", BestFitMapping = false, CharSet = CharSet.Unicode, 
            ExactSpelling = true, SetLastError = false, ThrowOnUnmappableChar = true)]
        private static extern int SHLoadIndirectString(string pszSource, 
            StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);
    
        private static string GetPackageDisplayName(Package package)
        {
            using (var key = Registry.ClassesRoot.OpenSubKey(
                @"Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel" + 
                $@"\Repository\Packages\{package.Id.FullName}\App\Capabilities"))
            {
                var sb = new StringBuilder(256);
                Shlwapi.SHLoadIndirectString((string)key.GetValue("ApplicationName"), 
                    sb, sb.Capacity, IntPtr.Zero);
                return sb.ToString();
            }
        }
    }
