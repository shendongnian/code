    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using Microsoft.Win32;
    
    public static class ComponentController
    {
        /// <summary>
        /// Is application running as administrator?
        /// </summary>
        public static Boolean IsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
    
            if (identity != null)
                return (new WindowsPrincipal(identity)).IsInRole(WindowsBuiltInRole.Administrator);
    
            return false;
        }
    
        public static Boolean IsWindowsVistaOrHigher()
        {
            OperatingSystem os = Environment.OSVersion;
            return ((os.Platform == PlatformID.Win32NT) && (os.Version.Major >= 6));
        }
    
        /// <summary>
        /// Add executable file of this app to registry startup path:
        /// 'LocalMachine\SOFTWARE\Microsoft\Windows\CurrentVersion\Run'
        /// </summary>
        /// <param name="targetEveryone">Run as administrator</param>
        public static void AddToStartup(Boolean targetEveryone)
        {
            try
            {
                using (RegistryKey main = (targetEveryone & IsAdmin() ? Registry.LocalMachine : Registry.CurrentUser))
                {
                    using (RegistryKey key = main.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        String fileName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
    
                        if (key.GetValue(fileName) == null)
                            key.SetValue(fileName, Application.ExecutablePath);
                    }
                }
            }
            catch (Exception ex)
            {
                // report exception ...
    
                //
                // Copy Shortcut To CommonStartUp or StartUp
                //
                try
                {
                    Environment.SpecialFolder folder = ((targetEveryone && IsWindowsVistaOrHigher()) ? Environment.SpecialFolder.CommonStartup : Environment.SpecialFolder.Startup);
                    String fileDestination = Path.Combine(Environment.GetFolderPath(folder), Path.GetFileNameWithoutExtension(Application.ExecutablePath)) + ".lnk";
    
                    if (!File.Exists(fileDestination))
                        Shortcut.Create(fileDestination, Application.ExecutablePath, null, null, "description...", null, null);
                }
                catch (Exception exp)
                {
                    // report exception ...
                }
            }
        }
    
    
        public class Shortcut
        {
            private static Type m_type = Type.GetTypeFromProgID("WScript.Shell");
            private static object m_shell = Activator.CreateInstance(m_type);
    
            [ComImport, TypeLibType((short)0x1040), Guid("F935DC23-1CF0-11D0-ADB9-00C04FD58A0B")]
            private interface IWshShortcut
            {
                [DispId(0)]
                string FullName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0)] get; }
    
                [DispId(0x3e8)]
                string Arguments { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x3e8)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x3e8)] set; }
    
                [DispId(0x3e9)]
                string Description { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x3e9)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x3e9)] set; }
    
                [DispId(0x3ea)]
                string Hotkey { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x3ea)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x3ea)] set; }
    
                [DispId(0x3eb)]
                string IconLocation { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x3eb)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x3eb)] set; }
    
                [DispId(0x3ec)]
                string RelativePath { [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x3ec)] set; }
    
                [DispId(0x3ed)]
                string TargetPath { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x3ed)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x3ed)] set; }
    
                [DispId(0x3ee)]
                int WindowStyle { [DispId(0x3ee)] get; [param: In] [DispId(0x3ee)] set; }
    
                [DispId(0x3ef)]
                string WorkingDirectory { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x3ef)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x3ef)] set; }
    
                [TypeLibFunc((short)0x40), DispId(0x7d0)]
                void Load([In, MarshalAs(UnmanagedType.BStr)] string PathLink);
    
                [DispId(0x7d1)]
                void Save();
            }
    
            public static void Create(string fileName, string targetPath, string arguments, string workingDirectory, string description, string hotkey, string iconPath)
            {
                IWshShortcut shortcut = (IWshShortcut)m_type.InvokeMember("CreateShortcut", System.Reflection.BindingFlags.InvokeMethod, null, m_shell, new object[] { fileName });
    
                shortcut.Description = description;
                shortcut.TargetPath = targetPath;
                shortcut.WorkingDirectory = string.IsNullOrEmpty(workingDirectory) ? targetPath : workingDirectory;
                shortcut.Arguments = arguments;
    
                if (!string.IsNullOrEmpty(hotkey)) shortcut.Hotkey = hotkey;
    
                if (!string.IsNullOrEmpty(iconPath)) shortcut.IconLocation = iconPath;
                else shortcut.IconLocation = System.Reflection.Assembly.LoadFile(targetPath).Location.Replace('\\', '/');
    
                shortcut.Save();
            }
        }
    }
