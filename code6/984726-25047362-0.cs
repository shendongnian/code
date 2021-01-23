    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    namespace KeyHook
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
                LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                IntPtr wParam, IntPtr lParam);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
    
            private const int WH_KEYBOARD_LL = 13;
            private const int WM_KEYDOWN = 0x0100;
            private const int WM_KEYUP = 0x0101;
            private LowLevelKeyboardProc _proc;
            private IntPtr _hookID = IntPtr.Zero;
            private bool CONTROL_DOWN = false;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _proc = HookCallback;
                _hookID = SetHook(_proc);
            }
    
            private IntPtr SetHook(LowLevelKeyboardProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
                }
            }
    
            private delegate IntPtr LowLevelKeyboardProc(
                int nCode, IntPtr wParam, IntPtr lParam);
    
            private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    if (((Keys)vkCode).ToString().Contains("ControlKey"))
                    {
                        this.CONTROL_DOWN = true;
                    }
                    else if (((Keys)vkCode).ToString() == "B" && this.CONTROL_DOWN)
                    {
                        this.pressedKeys.Text += "HOTKEY!" + Environment.NewLine;
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate() { this.pressedKeys.Text += "DOWN: " + (Keys)vkCode + Environment.NewLine; });
                    }
                }
                else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    if (((Keys)vkCode).ToString().Contains("ControlKey"))
                    {
                        this.CONTROL_DOWN = false;
                    }
                    this.Invoke((MethodInvoker)delegate() { this.pressedKeys.Text += "UP: " + (Keys)vkCode + Environment.NewLine; });
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                UnhookWindowsHookEx(_hookID);
            }
        }
    }
        
