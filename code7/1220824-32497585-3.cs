        private void AddToFolders(string CLSID)
        {
            RegistrySecurity security;
            RegistrySecurity originalRegSec = Permissions.RetrieveRegistryRights(@"HKEY_CLASSES_ROOT\CLSID\" + CLSID, out security);
            RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"CLSID\" + CLSID);
            int num = (int) key.GetValue("OldDescriptionID", -222);
            if (num == -222)
            {
                int num2 = (int) key.GetValue("DescriptionID", -1);
                key.SetValue("OldDescriptionID", num2);
            }
            key.SetValue("DescriptionID", 3);
            key.Close();
            Permissions.RestoreRegistryRights(@"HKEY_CLASSES_ROOT\CLSID\" + CLSID, originalRegSec);
            if (AppManager.is64BitProcess)
            {
                originalRegSec = null;
                originalRegSec = Permissions.RetrieveRegistryRights(@"HKEY_CLASSES_ROOT\Wow6432Node\CLSID\" + CLSID, out security);
                key = Registry.ClassesRoot.CreateSubKey(@"Wow6432Node\CLSID\" + CLSID);
                num = (int) key.GetValue("OldDescriptionID", -222);
                if (num == -222)
                {
                    int num3 = (int) key.GetValue("DescriptionID", -1);
                    key.SetValue("OldDescriptionID", num3);
                }
                key.SetValue("DescriptionID", 3);
                key.Close();
                Permissions.RestoreRegistryRights(@"HKEY_CLASSES_ROOT\Wow6432Node\CLSID\" + CLSID, originalRegSec);
            }
        }
        private void btnAddCustomFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK) return;
            string cLSID = string.Format("{{{0}}}", Guid.NewGuid());
            string subkey = @"CLSID\" + cLSID;
            string folder = folderBrowserDialog1.SelectedPath;
            string fileName = Path.GetFileName(folder);
            RegistryKey key = Registry.ClassesRoot.CreateSubKey(subkey);
            key.SetValue("", fileName);
                
            key.SetValue("performer", ProductName);
            key.SetValue("InfoTip", folder);
            key.Close();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                FileName = "reg.exe",
                Arguments = string.Format(@"ADD HKCR\{0} /v ""{{305ca226-d286-468e-b848-2b2e8e697b74}} 2"" /t REG_DWORD /d 0xffffffff /f", subkey),
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(startInfo);
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\DefaultIcon");
            key.SetValue("", @"%SystemRoot%\System32\shell32.dll,3");
            key.Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\InProcServer32");
            key.SetValue("", "shdocvw.dll");
            key.SetValue("ThreadingModel", "Both");
            key.Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\Instance");
            key.SetValue("CLSID", "{0afaced1-e828-11d1-9187-b532f1e9575d}");
            key.Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\Instance\InitPropertyBag");
            key.SetValue("Attributes", 0x15, RegistryValueKind.DWord);
            key.SetValue("Target", folder, RegistryValueKind.ExpandString);
            key.Close();
            Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx").Close();
            Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers").Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 1 general");
            key.SetValue("", "{21b22460-3aea-1069-a2dc-08002b30309d}");
            key.Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 2 customize");
            key.SetValue("", "{ef43ecfe-2ab9-4632-bf21-58909dd177f0}");
            key.Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 3 sharing");
            key.SetValue("", "{f81e9010-6ea4-11ce-a7ff-00aa003ca9f6}");
            key.Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 4 security");
            key.SetValue("", "{1f2e5c40-9550-11ce-99d2-00aa006e086c}");
            key.Close();
            key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellFolder");
            key.SetValue("WantsFORPARSING", "");
            key.SetValue("HideAsDeletePerUser", "");
            key.Close();
            startInfo.FileName = "reg.exe";
            startInfo.Arguments = string.Format(@"ADD HKCR\{0}\ShellFolder /v Attributes /t REG_DWORD /d 0xf080004d /f", subkey);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace");
            RegistryKey key2 = key.CreateSubKey(cLSID);
            if (key2 != null)
            {
                key2.SetValue("performer", ProductName, RegistryValueKind.String);
                key2.Close();
            }
            key.Close();
            if (AppManager.is64BitProcess)
            {
                subkey = @"Wow6432Node\CLSID\" + cLSID;
                key = Registry.ClassesRoot.CreateSubKey(subkey);
                key.SetValue("", fileName);
                key.SetValue("performer", ProductName);
                key.SetValue("InfoTip", folder);
                key.Close();
                startInfo = new ProcessStartInfo {
                    FileName = "reg.exe",
                    Arguments = string.Format(@"ADD HKCR\{0} /v ""{{305ca226-d286-468e-b848-2b2e8e697b74}} 2"" /t REG_DWORD /d 0xffffffff /f", subkey),
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(startInfo);
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\DefaultIcon");
                key.SetValue("", @"%SystemRoot%\System32\shell32.dll,3");
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\InProcServer32");
                key.SetValue("", "shdocvw.dll");
                key.SetValue("ThreadingModel", "Both");
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\Instance");
                key.SetValue("CLSID", "{0afaced1-e828-11d1-9187-b532f1e9575d}");
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\Instance\InitPropertyBag");
                key.SetValue("Attributes", 0x15, RegistryValueKind.DWord);
                key.SetValue("Target", folder, RegistryValueKind.ExpandString);
                key.Close();
                Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx").Close();
                Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers").Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 1 general");
                key.SetValue("", "{21b22460-3aea-1069-a2dc-08002b30309d}");
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 2 customize");
                key.SetValue("", "{ef43ecfe-2ab9-4632-bf21-58909dd177f0}");
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 3 sharing");
                key.SetValue("", "{f81e9010-6ea4-11ce-a7ff-00aa003ca9f6}");
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellEx\PropertySheetHandlers\tab 4 security");
                key.SetValue("", "{1f2e5c40-9550-11ce-99d2-00aa006e086c}");
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey(subkey + @"\ShellFolder");
                key.SetValue("WantsFORPARSING", "");
                key.SetValue("HideAsDeletePerUser", "");
                key.Close();
                startInfo.FileName = "reg.exe";
                startInfo.Arguments = string.Format(@"ADD HKCR\{0}\ShellFolder /v Attributes /t REG_DWORD /d 0xf080004d /f", subkey);
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
                key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace");
                RegistryKey key3 = key.CreateSubKey(cLSID);
                if (key3 != null)
                {
                    key3.SetValue("performer", ProductName, RegistryValueKind.String);
                    key3.Close();
                }
                key.Close();
            }
            AddToFolders(cLSID);
        }
