    Try
    {
        SldWorks swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
        swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSingleCommandPerPick, true); /// Single command per pick
        swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swEditMacroAfterRecord, true); /// Automatically edit macro after recording
        swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swUserEnableFreezeBar, true);  /// Enable Freeze bar
    
   
        Console.WriteLine("Settings applied");
    }
    catch()
    {
        Console.WriteLine("Failed to get SolidWorks");
    }
