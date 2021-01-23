                Log4NetInitializer.init();
                log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
                foreach (IAppender a in h.Root.Appenders)
                {
                    if (a.Name == "rollingFile")
                    {
                        FileAppender fa = (FileAppender)a;
                        string path = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"] + "\\" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
                        fa.File = path;
                        fa.ActivateOptions();
                        break;
                    }
                }
