    PostMessage(Process.GetProcessById(PID).MainWindowHandle, WM_KEYDOWN, ...);
    PostMessage(Process.GetProcessById(PID).MainWindowHandle, WM_KEYUP, ...);
    // Or use a single PostMessage call with a combination of KEYDOWN/KEYUP flags.
    InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
    InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
