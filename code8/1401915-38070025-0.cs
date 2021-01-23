    // Avoid screen locks while debugging.
    if (System.Diagnostics.Debugger.IsAttached)
    {
        PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
    }
