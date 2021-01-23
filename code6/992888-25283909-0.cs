    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace Maximize_IE
    {
        class Program
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            static void Main(string[] args)
            {
                var IE = new SHDocVw.InternetExplorer();
                object URL = "http://google.com/";
    
                IE.ToolBar = 0;
                IE.StatusBar = true;
                IE.MenuBar = true;
                IE.AddressBar = true;
    
                IE.Visible = true;
                ShowWindow((IntPtr)IE.HWND, 3);
                IE.Navigate2(ref URL);
                //ieOpened = true;
            }
        }
    }
