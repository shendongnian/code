    #region unmanaged
    // Declare the SetConsoleCtrlHandler function
    // as external and receiving a delegate.
    
    [DllImport("Kernel32")]
    public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
    
    // A delegate type to be used as the handler routine
    // for SetConsoleCtrlHandler.
    public delegate bool HandlerRoutine(CtrlTypes CtrlType);
    
    // An enumerated type for the control messages
    // sent to the handler routine.
    public enum CtrlTypes
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT,
        CTRL_CLOSE_EVENT,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT
    }
    
    #endregion
