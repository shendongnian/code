    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows.Forms;
    
    namespace Flicker
    {
        static class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            private struct Message
            {
                public IntPtr hWnd;
                public int msg;
                public IntPtr wParam;
                public IntPtr lParam;
                public uint time;
                public Point p;
            }
    
            [return: MarshalAs(UnmanagedType.Bool)]
            [SuppressUnmanagedCodeSecurity, DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);
    
            static Form1 form;
    
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                form = new Form1();
                Application.Idle += new EventHandler(Application_Idle);
                Application.Run(form);
            }
    
            static void Application_Idle(object sender, EventArgs e)
            {
                Message message;
                while (!PeekMessage(out message, IntPtr.Zero, 0, 0, 0))
                {
                    form.UpdateFrame();
                }
            }
        }
    }
