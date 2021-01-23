    [System.Security.SecuritySafeCritical]  // auto-generated
    public static void Sleep(int millisecondsTimeout)
    {
        SleepInternal(millisecondsTimeout);
        // Ensure we don't return to app code when the pause is underway
        if(AppDomainPauseManager.IsPaused)
            AppDomainPauseManager.ResumeEvent.WaitOneWithoutFAS();
    }
