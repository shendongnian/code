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
    
        public static string GetPackageDisplayName(Package package)
        {
            using (var registryHive = RegistryKey.OpenBaseKey(
                            RegistryHive.ClassesRoot, RegistryView.Registry32))
            {
                var capabilitiesKey = registryHive.OpenSubKey(
                   @"Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel"
                   + $@"\Repository\Packages\{package.Id.FullName}\App\Capabilities");
                var sb = new StringBuilder(256);
                SHLoadIndirectString((string)capabilitiesKey.GetValue("ApplicationName"), 
                   sb, sb.Capacity, IntPtr.Zero);
                return sb.ToString();
            }
        }
    }
