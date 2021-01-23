        public static Hashtable GetTypeAndIcon()
        {
            try
            {
                RegistryKey icoRoot = Registry.ClassesRoot;
                string[] keyNames = icoRoot.GetSubKeyNames();
                Hashtable iconsInfo = new Hashtable();
                foreach (string keyName in keyNames)
                {
                    if (String.IsNullOrEmpty(keyName)) continue;
                    int indexOfPoint = keyName.IndexOf(".");
                    
                    if (indexOfPoint != 0) continue;
                    RegistryKey icoFileType = icoRoot.OpenSubKey(keyName);
                    if (icoFileType == null) continue;
                    object defaultValue = icoFileType.GetValue("");
                    if (defaultValue == null) continue;
                    string defaultIcon = defaultValue.ToString() + "\\DefaultIcon";
                    RegistryKey icoFileIcon = icoRoot.OpenSubKey(defaultIcon);
                    if (icoFileIcon != null)
                    {
                        object value = icoFileIcon.GetValue("");
                        if (value != null)
                        {
                            string fileParam = value.ToString().Replace("\"", "");
                            iconsInfo.Add(keyName, fileParam);
                        }
                        icoFileIcon.Close();
                    }
                    icoFileType.Close();
                }
                icoRoot.Close();
                return iconsInfo;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
