    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleWindowPos
    {
        static class Imports
        {
            public static IntPtr HWND_BOTTOM = (IntPtr)1;
           // public static IntPtr HWND_NOTOPMOST = (IntPtr)-2;
            public static IntPtr HWND_TOP = (IntPtr)0;
            // public static IntPtr HWND_TOPMOST = (IntPtr)-1;
            public static uint SWP_NOSIZE = 1;
            public static uint SWP_NOZORDER = 4;
            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint wFlags);
        }
        class Program
        {
            static void Main(string[] args)
            {
                var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);
                System.Console.ReadLine();
            }
        }
    }
