     [DllImport("user32.dll")]
     static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
    
     const int WM_GETTEXT = 0x000D;
     const int WM_GETTEXTLENGTH = 0x000E;
    
     public static string GetControlText(IntPtr hWndOfControl)
      {    
        StringBuilder title = new StringBuilder();
    
        // Get the size of the string 
        Int32 size = SendMessage((int)hWndOfControl, WM_GETTEXTLENGTH, 0, 0).ToInt32();
    
         // If Size > 0 ? -> Text available...
         if (size > 0)
          {
           title = new StringBuilder(size + 1);    
           SendMessage(hWndOfControl, (int)WM_GETTEXT, title.Capacity, title);
          }
       
         return title.ToString();
       }
