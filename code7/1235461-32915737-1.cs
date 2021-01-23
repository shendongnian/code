    public sealed class DTesterConfiguration
    {
    
        private static DTesterConfigurationSection _config;
    
        static DTesterConfiguration()
        {
            _config = ((DTesterConfigurationSection)(global::System.Configuration.ConfigurationManager.GetSection("DTesterConfiguration")));
        }
    
        private DTesterConfiguration()
        {
        }
    
        public static DTesterConfigurationSection Config
        {
            get
            {
                return _config;
            }
        }
    }
    
    public sealed partial class DTesterConfigurationSection : System.Configuration.ConfigurationSection
    {
    
        [System.Configuration.ConfigurationPropertyAttribute("profiles")]
        [System.Configuration.ConfigurationCollectionAttribute(typeof(ProfilesElementCollection.ProfileElement), AddItemName = "profile")]
        public ProfilesElementCollection Profiles
        {
            get
            {
                return ((ProfilesElementCollection)(this["profiles"]));
            }
        }
    
        [System.Configuration.ConfigurationPropertyAttribute("option")]
        //[System.Configuration.ConfigurationCollectionAttribute(typeof(OptionElement), AddItemName = "option")]
        public OptionElement Option
        {
            get
            {
                return ((OptionElement)(this["option"]));
            }
        }
    
    
        //<option cmpResWithOacis="true" valRecentRosterPat="false"  maxPatCount="10" maxResCount="3" maxDetCount="3" />
        public sealed partial class OptionElement : System.Configuration.ConfigurationElement
        {
    
            [System.Configuration.ConfigurationPropertyAttribute("cmpResWithOacis", IsRequired = true)]
            public bool CmpResWithOacis
            {
                get
                {
                    return ((bool)(this["cmpResWithOacis"]));
                }
                set
                {
                    this["cmpResWithOacis"] = value;
                }
            }
    
            [System.Configuration.ConfigurationPropertyAttribute("valRecentRosterPat", IsRequired = true)]
            public bool ValRecentRosterPat
            {
                get
                {
                    return ((bool)(this["valRecentRosterPat"]));
                }
                set
                {
                    this["valRecentRosterPat"] = value;
                }
            }
    
            [System.Configuration.ConfigurationPropertyAttribute("maxPatCount", IsRequired = true)]
            public long MaxPatCount
            {
                get
                {
                    return ((long)(this["maxPatCount"]));
                }
                set
                {
                    this["maxPatCount"] = value;
                }
            }
    
            [System.Configuration.ConfigurationPropertyAttribute("maxResCount", IsRequired = true)]
            public long MaxResCount
            {
                get
                {
                    return ((long)(this["maxResCount"]));
                }
                set
                {
                    this["maxResCount"] = value;
                }
            }
    
            [System.Configuration.ConfigurationPropertyAttribute("maxDetCount", IsRequired = true)]
            public long MaxDetCount
            {
                get
                {
                    return ((long)(this["maxDetCount"]));
                }
                set
                {
                    this["maxDetCount"] = value;
                }
            }
    
    
        }
    
        public sealed partial class ProfilesElementCollection : System.Configuration.ConfigurationElementCollection
        {
    
            [System.Configuration.ConfigurationPropertyAttribute("defaultProfile", IsRequired = true)]
            public string DefaultProfile
            {
                get
                {
                    return ((string)(this["defaultProfile"]));
                }
                set
                {
                    this["defaultProfile"] = value;
                }
            }
    
            public ProfileElement this[int i]
            {
                get
                {
                    return ((ProfileElement)(this.BaseGet(i)));
                }
            }
    
            protected override System.Configuration.ConfigurationElement CreateNewElement()
            {
                return new ProfileElement();
            }
    
            protected override object GetElementKey(System.Configuration.ConfigurationElement element)
            {
                return ((ProfileElement)(element)).Site;
            }
    
            public sealed partial class ProfileElement : System.Configuration.ConfigurationElement
            {
    
                [System.Configuration.ConfigurationPropertyAttribute("site", IsRequired = true)]
                public string Site
                {
                    get
                    {
                        return ((string)(this["site"]));
                    }
                    set
                    {
                        this["site"] = value;
                    }
                }
    
                [System.Configuration.ConfigurationPropertyAttribute("urlscheme", IsRequired = true)]
                public string Urlscheme
                {
                    get
                    {
                        return ((string)(this["urlscheme"]));
                    }
                    set
                    {
                        this["urlscheme"] = value;
                    }
                }
    
                [System.Configuration.ConfigurationPropertyAttribute("urldomain", IsRequired = true)]
                public string Urldomain
                {
                    get
                    {
                        return ((string)(this["urldomain"]));
                    }
                    set
                    {
                        this["urldomain"] = value;
                    }
                }
    
                [System.Configuration.ConfigurationPropertyAttribute("dataSource")]
                public DataSourceElement DataSource
                {
                    get
                    {
                        return ((DataSourceElement)(this["dataSource"]));
                    }
                }
    
                [System.Configuration.ConfigurationPropertyAttribute("user")]
                public UserElement User
                {
                    get
                    {
                        return ((UserElement)(this["user"]));
                    }
                }
    
               
    
                public sealed partial class DataSourceElement : System.Configuration.ConfigurationElement
                {
    
                    [System.Configuration.ConfigurationPropertyAttribute("dataSource", IsRequired = true)]
                    public string DataSource
                    {
                        get
                        {
                            return ((string)(this["dataSource"]));
                        }
                        set
                        {
                            this["dataSource"] = value;
                        }
                    }
    
                    [System.Configuration.ConfigurationPropertyAttribute("databaseName", IsRequired = true)]
                    public string DatabaseName
                    {
                        get
                        {
                            return ((string)(this["databaseName"]));
                        }
                        set
                        {
                            this["databaseName"] = value;
                        }
                    }
    
                    [System.Configuration.ConfigurationPropertyAttribute("dbUserName", IsRequired = true)]
                    public string DbUserName
                    {
                        get
                        {
                            return ((string)(this["dbUserName"]));
                        }
                        set
                        {
                            this["dbUserName"] = value;
                        }
                    }
    
                    [System.Configuration.ConfigurationPropertyAttribute("dbUserPassword", IsRequired = true)]
                    public string DbUserPassword
                    {
                        get
                        {
                            return ((string)(this["dbUserPassword"]));
                        }
                        set
                        {
                            this["dbUserPassword"] = value;
                        }
                    }
                }
    
                public sealed partial class UserElement : System.Configuration.ConfigurationElement
                {
    
                    [System.Configuration.ConfigurationPropertyAttribute("userName", IsRequired = true)]
                    public string UserName
                    {
                        get
                        {
                            return ((string)(this["userName"]));
                        }
                        set
                        {
                            this["userName"] = value;
                        }
                    }
    
                    [System.Configuration.ConfigurationPropertyAttribute("password", IsRequired = true)]
                    public string Password
                    {
                        get
                        {
                            return ((string)(this["password"]));
                        }
                        set
                        {
                            this["password"] = value;
                        }
                    }
    
                    [System.Configuration.ConfigurationPropertyAttribute("TOHSoftwareVersion", IsRequired = true)]
                    public string TOHSoftwareVersion
                    {
                        get
                        {
                            return ((string)(this["TOHSoftwareVersion"]));
                        }
                        set
                        {
                            this["TOHSoftwareVersion"] = value;
                        }
                    }
    
                    [System.Configuration.ConfigurationPropertyAttribute("iOSVersion", IsRequired = true)]
                    public string IOSVersion
                    {
                        get
                        {
                            return ((string)(this["iOSVersion"]));
                        }
                        set
                        {
                            this["iOSVersion"] = value;
                        }
                    }
    
                    [System.Configuration.ConfigurationPropertyAttribute("deviceUDID", IsRequired = true)]
                    public string DeviceUDID
                    {
                        get
                        {
                            return ((string)(this["deviceUDID"]));
                        }
                        set
                        {
                            this["deviceUDID"] = value;
                        }
                    }
                }
            }
        }
    }
