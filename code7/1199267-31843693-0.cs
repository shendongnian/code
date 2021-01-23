    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text; 
    using System.Xml;
    public static class ConfigHub
    {
        #region State
        private static string WorkingDirectoryVar = null;
        private static string ConfigFileNameVar = null;
        private static bool AutoRefreshVar = true;
        private static bool VerboseVar = true;
        private static bool SetupExecutedVar = false;
        private static XmlDocument ConfigDocVar = new XmlDocument();
        private static Dictionary<string, string> ConfigLookupPair = new Dictionary<string, string>();
        private static Object ConfigHubLock = new Object();
        private const string CommentNameVar = "#comment";
        #endregion
    #region Property
    public static bool Verbose
    {
        get { return VerboseVar; }
        set { VerboseVar = value; }
    }
    public static bool AutoRefresh
    {
        get { return AutoRefreshVar; }
        set { AutoRefreshVar = value; }
    }
    public static bool SetupExecuted
    {
        get { return SetupExecutedVar; }
    }
    public static string ConfigFilePath
    {
        get { return WorkingDirectoryVar + @"\" + ConfigFileNameVar; }
    }
    public static string ConfigFileName
    {
        get { return ConfigFileNameVar; }
    }
    public static string WorkingDirectory
    {
        get { return WorkingDirectoryVar; }
    }
    #endregion
    #region Setup
    public static void Setup()
    {
        lock (ConfigHubLock)
        {
            //Initialize config with default
            WorkingDirectoryVar = Environment.CurrentDirectory;
            ConfigFileNameVar = "SCW.Config.xml";
            SetupExecutedVar = true;
            RefreshConfiguration();
        }
    }
    public static void Setup(string configFileName)
    {
        lock (ConfigHubLock)
        {
            //Initialize config with specified file
            WorkingDirectoryVar = Environment.CurrentDirectory;
            ConfigFileNameVar = configFileName.Trim().ToLower().Replace(".xml", "") + ".xml";
            SetupExecutedVar = true;
            RefreshConfiguration();
        }
    }
    #endregion
    #region Merchant
    public static void SetValue(string key, string value)
    {
        //Fail if setup hasn't been called
        if (!SetupExecutedVar) throw ConfigHubException.BuildException(ConfigHubExceptionType.NotSetup, "Setup must be called before using the ConfigHub", null);        
        try
        {            
            lock (ConfigHubLock)
            {
                //Set the value 
                bool foundNode = false;
                foreach (XmlNode configNode in ConfigDocVar.ChildNodes[0].ChildNodes)
                {
                    if (configNode.Name.Trim().ToLower() == key.Trim().ToLower())
                    {
                        configNode.InnerXml = value.Trim();
                        foundNode = true;
                    }
                }
                if (!foundNode)
                {
                    XmlNode newNode = ConfigDocVar.CreateNode("element", key.Trim(), "");
                    newNode.InnerXml = value.Trim();
                    ConfigDocVar.ChildNodes[0].AppendChild(newNode);
                }
                //Save the config file
                ConfigDocVar.Save(WorkingDirectoryVar + @"\" + ConfigFileNameVar);                
                RefreshConfiguration();
            }
        }
        catch (Exception err)
        {
            throw ConfigHubException.BuildException(ConfigHubExceptionType.SetValue, "Set value failed", err);
        }
    }
    public static string GetValue(string key)
    {
        //Fail if setup hasn't been called
        if (!SetupExecutedVar) throw ConfigHubException.BuildException(ConfigHubExceptionType.NotSetup, "Setup must be called before using the ConfigHub", null);
        if (AutoRefreshVar) RefreshConfiguration();
        try
        {
            lock (ConfigHubLock)
            {
                //Get and return the value
                if (AutoRefreshVar) RefreshConfiguration();
                if (ConfigLookupPair.ContainsKey(key.Trim().ToLower()))
                {
                    return ConfigLookupPair[key.Trim().ToLower()];
                }
                else
                {
                    throw ConfigHubException.BuildException(ConfigHubExceptionType.NoKeyFound, "The key " + key + " was not found", null);
                }
            }
        }
        catch (Exception err)
        {
            throw ConfigHubException.BuildException(ConfigHubExceptionType.GetValue, "Get value failed", err);
        }
    }
    public static void RefreshConfiguration()
    {
        //Fail if setup hasn't been called
        if (!SetupExecutedVar) throw ConfigHubException.BuildException(ConfigHubExceptionType.NotSetup, "Setup must be called before using the ConfigHub", null);
        try
        {
            //Load configuration from file
            ConfigDocVar.Load(WorkingDirectoryVar + @"\" + ConfigFileNameVar);
            List<string> duplicateCheck = new List<string>();
            foreach (XmlNode configNode in ConfigDocVar.ChildNodes[0].ChildNodes)
            {
                if (configNode.Name.Trim().ToLower() == CommentNameVar)
                {
                    //Ignore the Comment
                }
                else
                {
                    if (duplicateCheck.Contains(configNode.Name.Trim().ToLower()))
                    {
                        //Duplicate key failure
                        throw ConfigHubException.BuildException(ConfigHubExceptionType.DuplicateKey, "The key " + configNode.Name.Trim() + " appears multiple times", null);
                    }
                    else
                    {
                        //Add configuration key value pair
                        duplicateCheck.Add(configNode.Name.Trim().ToLower());
                        if (!ConfigLookupPair.ContainsKey(configNode.Name.Trim().ToLower()))
                        {
                            ConfigLookupPair.Add(configNode.Name.Trim().ToLower(), configNode.InnerXml.Trim());
                        }
                        else
                        {
                            ConfigLookupPair[configNode.Name.Trim().ToLower()] = configNode.InnerXml.Trim();
                        }
                    }
                }
            }
        }
        catch (Exception err)
        {
            //Look form root missing and multiple roots
            if (err.ToString().ToLower().Contains("root element is missing"))
            {
                throw ConfigHubException.BuildException(ConfigHubExceptionType.NoRootFound, "No configuration root found", err);
            }
            else if (err.ToString().ToLower().Contains("multiple root elements"))
            {
                throw ConfigHubException.BuildException(ConfigHubExceptionType.MultipleRoots, "Multiple configuration roots found", err);
            }
            else
            {
                throw ConfigHubException.BuildException(ConfigHubExceptionType.Refresh, "Refresh failed", err);
            }
        }
    }
    #endregion    
    }
    #region Exception
    public enum ConfigHubExceptionType { NotSetup, Setup, Refresh, DuplicateKey, NoKeyFound, SetValue, GetValue, NoRootFound, MultipleRoots }
    public class ConfigHubException : Exception
    {
        public ConfigHubException(ConfigHubExceptionType errType, string message) : base("#" + errType.ToString() + "-" + message + (ConfigHub.ConfigFilePath != @"\" ? " (" + ConfigHub.ConfigFilePath + ")" : "")) { }
        public ConfigHubException(ConfigHubExceptionType errType, string message, Exception innerException) : base("#" + errType.ToString() + "-" + message + (ConfigHub.ConfigFilePath != @"\" ? " (" + ConfigHub.ConfigFilePath + ")" : ""), innerException) { }
        public static ConfigHubException BuildException(ConfigHubExceptionType exceptionType, string message, Exception innerException)
        {
            if (!ConfigHub.Verbose || innerException == null) return new ConfigHubException(exceptionType, message);
            else return new ConfigHubException(exceptionType, message, innerException);      
        }
    }
    #endregion
