    public int CompareVersion(string NovoUpdate, string Config, bool ServiceChanged)
            {
                Global.Erro = "";
                Global.ErroGrave = false;
                int Status = 0;
                    ExeConfigurationFileMap configOld = new ExeConfigurationFileMap();
                    configOld.ExeConfigFilename = Config;
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configOld, ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["Version"] != null)
                {
                    string value = config.AppSettings.Settings["Version"].Value.ToString();
                    Version ver = Version.Parse(value);
                    Version versione = null;
                    if (System.IO.Path.GetFileName(NovoUpdate).ToLower() == "orcaservice")
                    {
                        string name2 = Directory.GetParent(NovoUpdate).ToString();
                        string Versionn = System.IO.Path.GetFileName(name2);
                        string[] Versions2 = Versionn.Split('_');
                        Version.TryParse(Versions2[2], out versione);
                    }
                    else
                    {
                       
    
                    }
                    if (ver < versione)
                        Status = 1;
                    else
                        Status = 0;
                }
    
                else Status = -1;
                
                
           
                
                return Status;
            }
