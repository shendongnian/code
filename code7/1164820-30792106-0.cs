    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.AddMessageFilter(new MyMessageFilter());  // hook filter up here
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    
        // ---- Customer Message Filter ---------
    
        class MyMessageFilter : IMessageFilter
        {
            public bool PreFilterMessage(ref System.Windows.Forms.Message Msg)
            {
                const int WM_LBUTTONDOWN = 0x0201;
    
                if (Msg.Msg == WM_LBUTTONDOWN)
                {
                    Control ClickedControl = System.Windows.Forms.Control.FromChildHandle(Msg.HWnd);
    
                    if (ClickedControl != null)
                        System.Diagnostics.Debug.WriteLine("Clicked Control: " + ClickedControl.Text);
                }
                return false;
            }
        }
    }
