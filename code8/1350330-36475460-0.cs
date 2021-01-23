    public static event ConsoleCancelEventHandler CancelKeyPress {
                    [System.Security.SecuritySafeCritical]  // auto-generated
                    [ResourceExposure(ResourceScope.Process)]
                    [ResourceConsumption(ResourceScope.Process)]
                    add {
                        new UIPermission(UIPermissionWindow.SafeTopLevelWindows).Demand();
         
                        lock(InternalSyncObject) {
                            // Add this delegate to the pile.
                            _cancelCallbacks += value;
         
                            // If we haven't registered our control-C handler, do it.
                            if (_hooker == null) {
                                _hooker = new ControlCHooker();
    // BUG: after you unsubscribe from CancelKeyPress it becomes null
    // and when you subscribe to CancelKeyPress again the call below will never be called. In the Remove part they will not set _hooker to null.
                            _hooker.Hook();
                        }
                    }
                }
                [System.Security.SecuritySafeCritical]  // auto-generated
                [ResourceExposure(ResourceScope.Process)]
                [ResourceConsumption(ResourceScope.Process)]
                remove {
                    new UIPermission(UIPermissionWindow.SafeTopLevelWindows).Demand();
     
                    lock(InternalSyncObject) {
                        // If count was 0, call SetConsoleCtrlEvent to remove cb.
                        _cancelCallbacks -= value;
                        Contract.Assert(_cancelCallbacks == null || _cancelCallbacks.GetInvocationList().Length > 0, "Teach Console::CancelKeyPress to handle a non-null but empty list of callbacks");
                        if (_hooker != null && _cancelCallbacks == null)
                            _hooker.Unhook();
    //BUG: It Unhooks but does not set _hooker to null.
                        }
                    }
                }
 
