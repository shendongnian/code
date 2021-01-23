    using System.Runtime.InteropServices;
    ...
    // Wrapper
    class CursorNativeMethods {
      [DllImport("User32.dll",
                 EntryPoint = "SetCursorPos",
                 CallingConvention = CallingConvention.Winapi)]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern Boolean SetCursorPos(Point point);
      ...
      [DllImport("User32.dll",
                 EntryPoint = "GetCursorPos",
                 CallingConvention = CallingConvention.Winapi)]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern Boolean GetCursorPos([Out] out Point point);
      ...
    }
    // Your Routine
    public static class MyCursor {
      public Point Location {
        get {
          Point pt = new Point(-1, -1); 
          if (CursorNativeMethods.GetCursorPos(out pt))
            return pt;
          else 
            return new Point(-1, -1); 
        } 
        set {
          CursorNativeMethods.SetCursorPos(value);
        }
      }
      ...
    } 
