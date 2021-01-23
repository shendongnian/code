    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Word = Microsoft.Office.Interop.Word;
    using Office = Microsoft.Office.Core;
    using Microsoft.Office.Tools.Word;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    namespace PersianWords
    {
        public partial class ThisAddIn
        {
            private const int WH_KEYBOARD_LL = 13;
            private const int WM_KEYDOWN = 0x0100;
            private static IntPtr hookId = IntPtr.Zero;
            private delegate IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam);
            private static HookProcedure procedure = HookCallback;
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, HookProcedure lpfn, IntPtr hMod, uint dwThreadId);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
            private static IntPtr SetHook(HookProcedure procedure)
            {
                using (Process process = Process.GetCurrentProcess())
                using (ProcessModule module = process.MainModule)
                    return SetWindowsHookEx(WH_KEYBOARD_LL, procedure, GetModuleHandle(module.ModuleName), 0);
            }
            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int pointerCode = Marshal.ReadInt32(lParam);
                    if (pointerCode == 162 || pointerCode == 160)
                    {
                        return CallNextHookEx(hookId, nCode, wParam, lParam);
                    }
                    string pressedKey = ((Keys)pointerCode).ToString();
                    //Do some sort of processing on key press
                    var thread = new Thread(() =>
                    {
                        MyClass.WrdApp.CustomizationContext = MyClass.WrdApp.ActiveDocument;
                        //do something with current document
                    });
                    thread.Start();
                }
                return CallNextHookEx(hookId, nCode, wParam, lParam);
            }
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                hookId = SetHook(procedure);
                MyClass.WrdApp = Application;
                MyClass.WrdApp.CustomizationContext = MyClass.WrdApp.ActiveDocument;
            }
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
                UnhookWindowsHookEx(hookId);
            }
        #region VSTO generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        #endregion
        }
    }
