     public class WindowHandle : System.Windows.Forms.IWin32Window
     {
          public WindowHandle(IntPtr handle)
          {
              _hwnd = handle;
          }
          public IntPtr Handle
          {
              get { return _hwnd; }
          }
          private IntPtr _hwnd;
       }
