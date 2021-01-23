     private static string GetStandardBrowserPath()
            {
                string browserPath = string.Empty;
                RegistryKey browserKey = null;
    
                try
                {
                    //Read default browser path from Win XP registry key
                    browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
    
                    //If browser path wasn't found, try Win Vista (and newer) registry key
                    if (browserKey == null)
                    {
                        browserKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
                    }
    
                    //If browser path was found, clean it
                    if (browserKey != null)
                    {
                        //Remove quotation marks
                        browserPath = (browserKey.GetValue(null) as string).ToLower().Replace("\"", "");
    
                        //Cut off optional parameters
                        if (!browserPath.EndsWith("exe"))
                        {
                            browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                        }
    
                        //Close registry key
                        browserKey.Close();
                    }
                }
                catch
                {
                    //Return empty string, if no path was found
                    return string.Empty;
                }
                //Return default browsers path
                return browserPath;
            }
