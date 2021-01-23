    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.IO;
    
    namespace DemoCalc
    {
    
        static class Program
        {
            [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                if (!IsAssociated())
                {
                    Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.abcd");
                    Asociate();
                }
                else
                {
                    Asociate();
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (args.Length == 0)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    Application.Run(new Form1(args[0]));
                }
            }
            public static bool IsAssociated()
            {
    
                return (Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.abcd", false) == null);
                
            }
            public static void Asociate()
            {
                String path = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
                MessageBox.Show(path);
                path = System.IO.Directory.GetParent(path).FullName + @"\Image\sync.ico";
                MessageBox.Show(path);
                RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.abcd");
                RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\MyCalcNew.exe");
                RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.abcd");
    
                FileReg.CreateSubKey("DefaultIcon").SetValue("", System.IO.Directory.GetParent(System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).FullName + @"\Image\sync.ico");
                FileReg.CreateSubKey("PerceivedType").SetValue("", "Text");
    
                AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("DefaultIcon").SetValue("", System.IO.Directory.GetParent(System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).FullName + @"\Image\sync.ico");
    
                AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\MyCalcNew.exe");
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
