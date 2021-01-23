        public static bool doesSettingExist(string pSettingName)
        {
            List<string> l_Settings = null;
            string l_Value = string.Empty;
            bool l_Return = false;
            try
            {
                // initialises the new list
                l_Settings = new List<string>();
                // feeds the list dictionary
                foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
                {
                    if (Properties.Settings.Default[currentProperty.Name] != null)
                    {
                        l_Settings.Add(currentProperty.Name);
                    }
                }
                if (l_Settings.Contains(pSettingName))
                {
                    l_Return = true;
                }
            }
            catch (Exception exc)
            {
                ClsErrorManager.manageException(exc);
            }
            finally
            {
            }
            return l_Return;
        }
