    using IWshRuntimeLibrary;
    public string test()
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var list = Directory.EnumerateFiles(path);
                foreach(var v in list)
                {
                    var extension = Path.GetExtension(v);
                    if (extension.Equals(".lnk", StringComparison.InvariantCultureIgnoreCase))
                    {
                        WshShell shell = new WshShell(); 
                        IWshShortcut link = (IWshShortcut) shell.CreateShortcut(v);
                        if (Path.GetFileName(link.TargetPath).Equals("mspaint.exe", StringComparison.InvariantCultureIgnoreCase))
                        {
                            return link.TargetPath;
                        }
                    }
                }
                return null;
            }
