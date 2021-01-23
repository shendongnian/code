    #if FULLFRAMEWORK
            private bool DoSomethingFullFrameworkSpecific()
            {
                var connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionStringName];
                return connectionStringSetting != null;
            }
    #endif
