    using IWshRuntimeLibrary;
    public string test()
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var list = Directory.EnumerateFiles(path);
                foreach(var v in list)
                {
                    if (v.ToUpper().Contains("LNK"))
                    {
                        WshShell shell = new WshShell(); 
                        IWshShortcut link = (IWshShortcut) shell.CreateShortcut(v);
                        if (link.TargetPath.ToUpper().Contains("MSPAINT"))
                        {
                            return link.TargetPath;
                        }                    
                    }                
                }
                return null;
            }
