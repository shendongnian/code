                if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                {
                    objRegistryKey.SetValue("DisableTaskMgr", "1");
                    lblTaskManager.Text = ("Disabled");
                }
                else
                {
                    objRegistryKey.DeleteValue("DisableTaskMgr");
                    objRegistryKey.Close();
                    lblTaskManager.Text = ("Enabled");
                }
