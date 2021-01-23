        private static void SetIEVersioneKeyforWebBrowserControl(string appName, int ieval)
        {
            RegistryKey Regkey = null;
            try
            {
                Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                //If the path is not correct or 
                //If user't have priviledges to access registry 
                if (Regkey == null)
                {
                    _logger.Error("Application FEATURE_BROWSER_EMULATION Failed - Registry key Not found");
                    return;
                }
                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                //Check if key is already present 
                if (FindAppkey == ieval.ToString())
                {
                    _logger.Debug("Application FEATURE_BROWSER_EMULATION already set to " + ieval);
                    Regkey.Close();
                    return;
                }
                //If key is not present or different from desired, add/modify the key , key value 
                Regkey.SetValue(appName, unchecked((int)ieval), RegistryValueKind.DWord);
                //check for the key after adding 
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                if (FindAppkey == ieval.ToString())
                {
                    _logger.Info("Application FEATURE_BROWSER_EMULATION changed to " + ieval + "; changes will be visible at application restart");
                }
                else
                {
                    _logger.Error("Application FEATURE_BROWSER_EMULATION setting failed; current value is  " + ieval);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Application FEATURE_BROWSER_EMULATION setting failed; " + ex.Message);
            }
            finally
            {
                //Close the Registry 
                if (Regkey != null) Regkey.Close();
            }
        }
