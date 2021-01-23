     [DllImport("User32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
            private void closeWindow()
             {
              // retrieve the handler of the window  
                int iHandle = FindWindow("CabinetWClass", "Personalization");
                if (iHandle > 0)
                 {
                     SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);  
                 }  
              }   
 
