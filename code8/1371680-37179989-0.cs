        var settingsManager = new ShellSettingsManager(ServiceProvider);
        var settingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);
        if (settingsStore.PropertyExists(CollectionPath, TabSize))
        {
          settingsStore.SetUInt32(CollectionPath, TabSize, 2);
          _dte2.Properties["TextEditor", "CSharp"].Item("TabSize").Value = 2;
        }
        if (settingsStore.PropertyExists(CollectionPath, IndentSize))
        {
          settingsStore.SetUInt32(CollectionPath, IndentSize, 2);
          _dte2.Properties["TextEditor", "CSharp"].Item("IndentSize").Value = 2;
        }
        _dte2.Commands.Raise(VSConstants.CMDSETID.StandardCommandSet2K_string, (int)VSConstants.VSStd2KCmdID.FORMATDOCUMENT, null, null);
