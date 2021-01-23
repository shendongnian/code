        public static string GetConnectionString()
        {
            return GetConnectionString(null);
        } // End Function GetConnectionString
        protected static string strStaticConnectionString = null;
        public static string GetConnectionString(string strIntitialCatalog)
        {
            string strReturnValue = null;
            string strProviderName = null;
            if (string.IsNullOrEmpty(strStaticConnectionString))
            {
                string strConnectionStringName = System.Environment.MachineName;
                if (string.IsNullOrEmpty(strConnectionStringName))
                {
                    strConnectionStringName = "LocalSqlServer";
                }
                System.Configuration.ConnectionStringSettingsCollection settings = System.Configuration.ConfigurationManager.ConnectionStrings;
                if ((settings != null))
                {
                    foreach (System.Configuration.ConnectionStringSettings cs in settings)
                    {
                        if (StringComparer.OrdinalIgnoreCase.Equals(cs.Name, strConnectionStringName))
                        {
                            strReturnValue = cs.ConnectionString;
                            strProviderName = cs.ProviderName;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                if (string.IsNullOrEmpty(strReturnValue))
                {
                    strConnectionStringName = "server";
                    System.Configuration.ConnectionStringSettings conString = System.Configuration.ConfigurationManager.ConnectionStrings[strConnectionStringName];
                    if (conString != null)
                    {
                        strReturnValue = conString.ConnectionString;
                    }
                }
                if (string.IsNullOrEmpty(strReturnValue))
                {
                    throw new ArgumentNullException("ConnectionString \"" + strConnectionStringName + "\" in file web.config.");
                }
                settings = null;
                strConnectionStringName = null;
            }
            else
            {
                if (string.IsNullOrEmpty(strIntitialCatalog))
                {
                    return strStaticConnectionString;
                }
                strReturnValue = strStaticConnectionString;
            }
            InitFactory(strProviderName);
            System.Data.Common.DbConnectionStringBuilder sb = GetConnectionStringBuilder(strReturnValue);
            if (string.IsNullOrEmpty(strStaticConnectionString))
            {
                if (!Convert.ToBoolean(sb["Integrated Security"]))
                {
                    sb["Password"] = DES.DeCrypt(System.Convert.ToString(sb["Password"]));
                }
                strReturnValue = sb.ConnectionString;
                strStaticConnectionString = strReturnValue;
            }
            if (!string.IsNullOrEmpty(strIntitialCatalog))
            {
                sb["Database"] = strIntitialCatalog;
            }
            strReturnValue = sb.ConnectionString;
            sb = null;
            return strReturnValue;
        } // End Function GetConnectionString
