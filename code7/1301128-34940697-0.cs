      using (RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
               "@Software\Microsoft\Windows\CurrentVersion\Policies\System")) {
        if (objRegistryKey.GetValue("DisableTaskMgr") == null) {
          objRegistryKey.SetValue("DisableTaskMgr", "1");
          lblTaskManager.Text = "Disabled";
        }
        else {
          objRegistryKey.DeleteValue("DisableTaskMgr");
          lblTaskManager.Text = "Enabled";
        }
      }
