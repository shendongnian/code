     public ServiceModelSectionGroup GetServiceModelSectionGroup() {
            var cfg = GetConfig();
            
            ServiceModelSectionGroup serviceModelSection = ServiceModelSectionGroup.GetSectionGroup(cfg);
            return serviceModelSection;
        }
    public Configuration GetConfig() {
            if (_cfg == null) {
                if (HostingEnvironment.IsHosted) // running inside asp.net ?
                { //yes so read web.config at hosting virtual path level
                    _cfg = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
                }
                else { //no, se we are testing or running exe version admin tool for example, look for an APP.CONFIG file
                    //var x = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                    _cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                }
            }
            return _cfg;
        }
