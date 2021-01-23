    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            [DllImport("User32.dll")]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("User32.dll")]
            private static extern int SetForegroundWindow(IntPtr hWnd);
    
            private const string DesiredWindowTitle = "(Desired Window Name)";
    
            // do not invoke the method to find the window when the form was constructing
            // private static IntPtr DesiredWindow = FindWindow(null, DesiredWindowTitle);
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // find the window at run time
                IntPtr DesiredWindow = FindWindow(null, DesiredWindowTitle);
    
                if (DesiredWindow == IntPtr.Zero)
                {
                    return; //Do not send KeyPress
                }
    
                SetForegroundWindow(DesiredWindow);
                Thread.Sleep(50);
                Keyboard.KeyPress(Keys.(WhateverKey));
            }
        }
    }
