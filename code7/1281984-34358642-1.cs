    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class RichTextBox5 : RichTextBox {
        protected override CreateParams CreateParams {
            get {
                if (moduleHandle == IntPtr.Zero) {
                    moduleHandle = LoadLibrary("msftedit.dll");
                    if ((long)moduleHandle < 0x20) throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not load Msftedit.dll");
                }
                var cp = base.CreateParams;
                cp.ClassName = "RichEdit50W";
                return cp;
            }
        }
        private static IntPtr moduleHandle;
    
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpFileName);
    }
