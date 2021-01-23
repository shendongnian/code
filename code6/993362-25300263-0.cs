    EnvDTE.DebuggerEvents _dteDebuggerEvents;
    _dteDebuggerEvents = VsObject.DTE.Events.DebuggerEvents;
    _dteDebuggerEvents.OnEnterDesignMode += _dteDebuggerEvents_OnEnterDesignMode;
    _dteDebuggerEvents.OnContextChanged += _dteDebuggerEvents_OnContextChanged;
    void _dteDebuggerEvents_OnEnterDesignMode(dbgEventReason Reason)
    {
       switch (Reason)
       {
           case dbgEventReason.dbgEventReasonStopDebugging:
                 // do whatever you need here
           break;
       }
    }
