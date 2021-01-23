    RegistryKey subKey2 = subKey1.CreateSubKey(verb.Name.ToLower());
_
    protected void SetVerbs(ProgramVerb[] verbs)
    {
      if (!this.Exists)
        throw new Exception("Extension does not exist");
      RegistryKey registryKey = RegistryHelper.AssociationsRoot.OpenSubKey(this.progId, true);
      if (registryKey.OpenSubKey("shell", true) != null)
        registryKey.DeleteSubKeyTree("shell");
      RegistryKey subKey1 = registryKey.CreateSubKey("shell");
      foreach (ProgramVerb verb in verbs)
      {
        RegistryKey subKey2 = subKey1.CreateSubKey(verb.Name.ToLower());
        RegistryKey subKey3 = subKey2.CreateSubKey("command");
        subKey3.SetValue(string.Empty, (object) verb.Command, RegistryValueKind.ExpandString);
        subKey3.Close();
        subKey2.Close();
      }
      ShellNotification.NotifyOfChange();
    }
