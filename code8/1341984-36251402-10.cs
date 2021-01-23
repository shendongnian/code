    public JsonResult RemoteBrowse(string Protocol, string Host, int Port, string Username, string Password, string Directory, string Fingerprint = "")
    {
        dynamic Connector = null;
        MyMember.Init(User.Identity.Name);
        if (MyMember.ID_Member > 0)
        {
            if (Protocol == "ftp")
                Connector = new FTPDirectory();
            else if (Protocol == "sftp")
                Connector = new SFTPDirectory();
            else if (Protocol == "local")
                Connector = new LocalDirectory();
            if (Connector != null)
            {
                try
                {
                    Connector.Connect(Host, Port, Username, Password, Fingerprint);
                    while (true)
                    {
                        Boolean Mod = false;
                        if (Directory.Length >= 2)
                        {
                            if (Directory.Substring(0, 2) == "//")
                            {
                                Directory = Directory.Substring(1);
                                Mod = true;
                            }
                            else if (Directory.Substring(0, 2) == "..")
                            {
                                Directory = Directory.Substring(2);
                                Mod = true;
                            }
                        }
                        else if (Directory.Length >= 3)
                        {
                            if (Directory.Substring(0, 3) == "/..")
                            {
                                Directory = Directory.Substring(3);
                                Mod = true;
                            }
                        }
                        if (!Mod)
                            break;
                    }
                    if (Directory.Length > 1 && Directory != "/")
                    {
                        if (Directory.Substring(0, 1) != "/")
                            Directory = "/" + Directory;
                        if (Directory.Substring(Directory.Length - 1) == "/")
                            Directory = Directory.Substring(0, Directory.Length - 1);
                        if (Directory.Substring(Directory.Length - 3) == "/..")     // go one directory up
                        {
                            Directory = Directory.Substring(0, Directory.Length - 3);
                            Directory = Directory.Substring(0, Directory.LastIndexOf('/'));
                        }
                    }
                    if (Directory == "")
                        Directory = "/";
                    Connector.Info.CurrentDirectory = Connector.GetWorkingDirectory(Directory);
                    Connector.ListDirectory(Directory);
                    Connector.Disconnect();
                }
                catch (Exception ex)
                {
                    Connector.Info.Error = ex.Message;
                    if (ex.InnerException != null)
                        Connector.Info.Error += '\n' + ex.InnerException.Message;
                }
            }
        }
        return Json((Connector != null) ? Connector.Info : null, JsonRequestBehavior.AllowGet);
    }
