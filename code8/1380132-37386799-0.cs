    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Interop;
    using Microsoft.Win32;
   
    [DllImport("user32.Dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumChildWindows(IntPtr parentHandle,     Win32Callback callback, IntPtr lParam);
    Process[] p = System.Diagnostics.Process.GetProcessesByName("StikyNot"); //this is for sticky notes
    foreach (Process p1 in p)
            {                
                IntPtr MainWindowHandle = p1.MainWindowHandle;              
                List<IntPtr> GetChildWindowsHandle=GetChildWindows(MainWindowHandle);
            }
     public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                Win32Callback childProc = new Win32Callback(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }
