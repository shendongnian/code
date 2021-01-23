    private static readonly ILog Log = LogManager.GetLogger(
        MethodBase.GetCurrentMethod().DeclaringType);
    public void TurnOnScreenAndInterruptScreensaver()
    {
        TryTurnOnScreenAndResetDisplayIdleTimer();
        TryInterruptScreensaver();
    }
    /// <summary>
    /// Moves the mouse which turns on a turned-off screen and also resets the 
    /// display idle timer, which is key, because otherwise the 
    /// screen would be turned off again immediately.
    /// </summary>
    private static void TryTurnOnScreenAndResetDisplayIdleTimer()
    {
        var input = new SendInputNativeMethods.Input {
            type = SendInputNativeMethods.SendInputEventType.InputMouse, };
        try
        {
            SendInputNativeMethods.SendInput(input);
        }
        catch (Win32Exception exception)
        {
            Log.Error("Could not send mouse move input to turn on display", exception);
        }
    }
    private static void TryInterruptScreensaver()
    {
        try
        {
            if (ScreensaverNativeMethods.GetScreenSaverRunning())
            {
                ScreensaverNativeMethods.KillScreenSaver();
            }
            // activate screen saver again so that after idle-"timeout" it shows again
            ScreensaverNativeMethods.ActivateScreensaver();
        }
        catch (Win32Exception exception)
        {
            Log.Error("Screensaver could not be deactivated", exception);
        }
    }
