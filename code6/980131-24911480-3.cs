    public static void ShowWindowsMenu(bool enable) {
      try {
        if (enable) {
          if (_taskBar != IntPtr.Zero) {
            SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 240, 26, (int)WindowPosition.SWP_SHOWWINDOW); // display the start bar
          }
        } else {
          _taskBar = FindWindowCE("HHTaskBar", null); // Find the handle to the Start Bar
          if (_taskBar != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 0, 0, (int)WindowPosition.SWP_HIDEWINDOW); // Hide the start bar
          }
        }
      } catch (Exception err) {
        ErrorWrapper(enable ? "Show Start" : "Hide Start", err);
      }
      try {
        if (enable) {
          if (_sipButton != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 240, 26, (int)WindowPosition.SWP_SHOWWINDOW); // display the start bar
          }
        } else {
          _sipButton = FindWindowCE("MS_SIPBUTTON", "MS_SIPBUTTON");
          if (_sipButton != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 0, 0, (int)WindowPosition.SWP_HIDEWINDOW); // Hide the start bar
          }
        }
      } catch (Exception err) {
        ErrorWrapper(enable ? "Show SIP" : "Hide SIP", err);
      }
    }
