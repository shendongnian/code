      public partial class BasicAwesomiumComponent : DrawableGameComponent {
      private delegate Int32 ProcessMessagesDelegate(Int32 code, Int32 wParam, ref Message lParam);
      private static class User32 {
         [DllImport("user32.dll", SetLastError = true)]
         internal static extern IntPtr SetWindowsHookEx(Int32 windowsHookId, ProcessMessagesDelegate function, IntPtr mod, Int32 threadId);
         [DllImport("user32.dll", SetLastError = true)]
         internal static extern Int32 UnhookWindowsHookEx(IntPtr hook);
         [DllImport("user32.dll", SetLastError = true)]
         internal static extern Int32 CallNextHookEx(IntPtr hook, Int32 code, Int32 wParam, ref Message lParam);
         [DllImport("user32.dll", SetLastError = true)]
         internal static extern Boolean TranslateMessage(ref Message message);
         [DllImport("user32.dll", CharSet = CharSet.Auto)]
         internal static extern IntPtr FindWindow(String className, String windowName);
         [DllImport("user32.dll", CharSet = CharSet.Auto)]
         internal static extern int RegisterWindowMessage(String msg);
         [DllImport("user32.dll", CharSet = CharSet.Auto)]
         internal static extern IntPtr SendMessage(HandleRef hWnd, Int32 msg, Int32 wParam, Int32 lParam);
         [DllImport("user32.dll", CharSet = CharSet.Auto)]
         internal static extern bool SystemParametersInfo(Int32 nAction, Int32 nParam, ref Int32 value, Int32 ignore);
         [DllImport("user32.dll", CharSet = CharSet.Auto)]
         internal static extern int GetSystemMetrics(Int32 nIndex);
      }
      private static class Kernel32 {
         [DllImport("kernel32.dll", SetLastError = true)]
         internal static extern Int32 GetCurrentThreadId();
      }
      private static class SystemMetrics {
         internal static Int32 MouseWheelScrollDelta {
            get {
               return 120;
            }
         }
         internal static Int32 MouseWheelScrollLines {
            get {
               var scrollLines = 0;
               if (User32.GetSystemMetrics(75) == 0) {
                  var hwnd = User32.FindWindow("MouseZ", "Magellan MSWHEEL");
                  if (hwnd != IntPtr.Zero) {
                     var windowMessage = User32.RegisterWindowMessage("MSH_SCROLL_LINES_MSG");
                     scrollLines = (Int32)User32.SendMessage(new HandleRef(null, hwnd), windowMessage, 0, 0);
                     if (scrollLines != 0) {
                        return scrollLines;
                     }
                  }
                  return 3;
               }
               User32.SystemParametersInfo(104, 0, ref scrollLines, 0);
               return scrollLines;
            }
         }
      }
      private enum WindowsMessage {
         KeyDown = 0x0100,
         KeyUp = 0x0101,
         Char = 0x0102,
         MouseMove = 0x0200,
         LeftButtonDown = 0x0201,
         LeftButtonUp = 0x0202,
         LeftButtonDoubleClick = 0x0203,
         RightButtonDown = 0x0204,
         RightButtonUp = 0x0205,
         RightButtonDoubleClick = 0x0206,
         MiddleButtonDown = 0x0207,
         MiddleButtonUp = 0x0208,
         MiddleButtonDoubleClick = 0x0209,
         MouseWheel = 0x020A,
      }
      private struct Message {
         internal IntPtr HWnd;
         internal Int32 Msg;
         internal IntPtr WParam;
         internal IntPtr LParam;
         internal IntPtr Result;
      }
      private IntPtr hookHandle;
      private ProcessMessagesDelegate processMessages;
      private Int32 ProcessMessages(Int32 code, Int32 wParam, ref Message lParam) {
         if (this.Enabled && code == 0 && wParam == 1) {
            bool processed = false;
            switch ((WindowsMessage)lParam.Msg) {
               case WindowsMessage.KeyDown:
               case WindowsMessage.KeyUp:
               case WindowsMessage.Char:
                  WebKeyboardEvent keyboardEvent = new WebKeyboardEvent((uint)lParam.Msg, lParam.WParam, lParam.LParam, 0);
                  awesomiumContext.Post(state => {
                     if (!WebView.IsLive) return;
                     WebView.InjectKeyboardEvent(keyboardEvent);
                  }, null);
                  processed = true;
                  break;
               case WindowsMessage.MouseWheel:
                  var delta = (((Int32)lParam.WParam) >> 16);
                  awesomiumContext.Post(state => {
                     if (!WebView.IsLive) return;
                     WebView.InjectMouseWheel(delta / SystemMetrics.MouseWheelScrollDelta * 16 * SystemMetrics.MouseWheelScrollLines, 0);
                  }, null);
                  processed = true;
                  break;
            }
            if (!processed) {
               WindowsMessage message = (WindowsMessage)lParam.Msg;
               awesomiumContext.Post(state => {
                  if (!WebView.IsLive) return;
                  switch (message) {
                     case WindowsMessage.MouseMove:
                        var mouse = Mouse.GetState();
                        WebView.InjectMouseMove(mouse.X - area.X, mouse.Y - area.Y);
                        break;
                     case WindowsMessage.LeftButtonDown:
                        WebView.InjectMouseDown(MouseButton.Left);
                        break;
                     case WindowsMessage.LeftButtonUp:
                        WebView.InjectMouseUp(MouseButton.Left);
                        break;
                     case WindowsMessage.LeftButtonDoubleClick:
                        WebView.InjectMouseDown(MouseButton.Left);
                        break;
                     case WindowsMessage.RightButtonDown:
                        WebView.InjectMouseDown(MouseButton.Right);
                        break;
                     case WindowsMessage.RightButtonUp:
                        WebView.InjectMouseUp(MouseButton.Right);
                        break;
                     case WindowsMessage.RightButtonDoubleClick:
                        WebView.InjectMouseDown(MouseButton.Right);
                        break;
                     case WindowsMessage.MiddleButtonDown:
                        WebView.InjectMouseDown(MouseButton.Middle);
                        break;
                     case WindowsMessage.MiddleButtonUp:
                        WebView.InjectMouseUp(MouseButton.Middle);
                        break;
                     case WindowsMessage.MiddleButtonDoubleClick:
                        WebView.InjectMouseDown(MouseButton.Middle);
                        break;
                  }
               }, null);
            }
            User32.TranslateMessage(ref lParam);
         }
         return User32.CallNextHookEx(IntPtr.Zero, code, wParam, ref lParam);
      }
    }
