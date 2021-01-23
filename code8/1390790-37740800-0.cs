    public void scriptTables()
            {
                try
                {
                    string folder = HttpContext.Current.Server.MapPath("~/Excels/data.sql");// I have this file 
                    System.IO.File.WriteAllText(folder, string.Empty);
    
                    ServerConnection serverConnection = new ServerConnection();
                    serverConnection.LoginSecure = false;
                    serverConnection.ServerInstance = ConfigurationManager.AppSettings["Server"];
                    serverConnection.Login = ConfigurationManager.AppSettings["SmoUser"];
                    serverConnection.Password = ConfigurationManager.AppSettings["SmoPass"];
                    serverConnection.DatabaseName = ConfigurationManager.AppSettings["Database"];
    
                    Server myServer = new Server(serverConnection);
                    Database CMSDB = myServer.Databases[ConfigurationManager.AppSettings["Database"]];
    
    
                    Scripter script = new Scripter(myServer);
                    ScriptingOptions so = new ScriptingOptions();
                    so.AnsiPadding = true;
                    so.IncludeHeaders = true;
                    so.Default = true;
                    so.DriForeignKeys = true;
                    so.DriPrimaryKey = true;
                    so.DriUniqueKeys = true;
                    so.ScriptData = true;
                    so.ScriptSchema = true;
                    so.ScriptDrops = false;
                    script.Options = so;
    
                    StringBuilder ss = new StringBuilder();
                    
                    foreach (Table table in CMSDB.Tables)
                    {
                        string tables = table.Name;
                        foreach (string s in script.EnumScript(new Urn[] { table.Urn }))
                            ss.Append(s);
                    }
                    System.IO.File.WriteAllText(folder, ss.ToString());
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ClearHeaders();
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.AddHeader("Content-Disposition",
                        "attachment; filename=" + "LeadBackup" + DateTime.Now.Date.ToString("d") + ".sql");
                    HttpContext.Current.Response.AddHeader("Content-Length", folder.Length.ToString());
                    HttpContext.Current.Response.ContentType = "text/plain";
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.TransmitFile(folder);
                    HttpContext.Current.Response.End();
    
                }
                catch (Exception e)
                {
                    Response.Write(e.Message);
                }
            }
