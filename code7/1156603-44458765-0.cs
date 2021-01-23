    public class Firewall
    {
        private const string CLSID_FIREWALL_MANAGER = "{304CE942-6E39-40D8-943A-B913C40C9CD4}";
        private const string PROGID_AUTHORIZED_APPLICATION = "HNetCfg.FwAuthorizedApplication";
        private const string PROGID_OPEN_PORT = "HNetCfg.FWOpenPort";
        private const string PROGID_POLITCY2 = "HNetCfg.FwPolicy2";
    
        [Flags]
        public enum PROFILE { DOMAIN = 1, PRIVATE = 2, PUBLIC = 5 };
    
        /// <summary>
        /// Create instance of the INetFwMgr that provides access to the firewall settings for a computer.
        /// </summary>
        /// <returns></returns>
        private static INetFwMgr GetFirewallManager()
        {
            Type objectType = Type.GetTypeFromCLSID(new Guid(CLSID_FIREWALL_MANAGER));
    
            return Activator.CreateInstance(objectType) as NetFwTypeLib.INetFwMgr;
        }
    
    
        /// <summary>
        /// Enable firewall
        /// </summary>
        public static void Enable()
        {
            INetFwMgr manager = Firewall.GetFirewallManager();
    
            bool isFirewallEnabled = manager.LocalPolicy.CurrentProfile.FirewallEnabled;
    
            if (isFirewallEnabled == false)
                manager.LocalPolicy.CurrentProfile.FirewallEnabled = true;
        }
    
    
        /// <summary>
        /// Authorize application
        /// </summary>
        /// <param name="title"></param>
        /// <param name="applicationPath"></param>
        /// <param name="scope"></param>
        /// <param name="ipVersion"></param>
        /// <returns></returns>
        public static bool AuthorizeApplication(string title, string applicationPath, NET_FW_SCOPE_ scope, NET_FW_IP_VERSION_ ipVersion)
        {
            // Create the type from prog id
            Type type = Type.GetTypeFromProgID(PROGID_AUTHORIZED_APPLICATION);
    
            // Create instance that provides access to the properties of an application that has been authorized have openings in the firewall.
            INetFwAuthorizedApplication auth = Activator.CreateInstance(type) as INetFwAuthorizedApplication;
            auth.Name = title;
            auth.ProcessImageFileName = applicationPath;
            auth.Scope = scope;
            auth.IpVersion = ipVersion;
            auth.Enabled = true;
    
    
            INetFwMgr manager = GetFirewallManager();
            try
            {
                manager.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(auth);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    
        /// <summary>
        /// Open port in network windows firewall
        /// </summary>
        /// <param name="name"></param>
        /// <param name="portNo"></param>
        /// <param name="scope"></param>
        /// <param name="protocol"></param>
        /// <param name="ipVersion"></param>
        /// <returns></returns>
        public static bool GloballyOpenPort(string name, int portNo,
                                            NET_FW_SCOPE_ scope, NET_FW_IP_PROTOCOL_ protocol, NET_FW_IP_VERSION_ ipVersion)
        {
            INetFwMgr manager = GetFirewallManager();
            try
            {
                // Check if port does not exists.
                bool exists = false;
                foreach (INetFwOpenPort openPort in manager.LocalPolicy.CurrentProfile.GloballyOpenPorts)
                {
                    if (openPort.Name == name && openPort.Port == portNo)
                    {
                        exists = true;
                        break;
                    }
                }
    
                if (!exists)
                {
                    // Create the type from prog id
                    Type type = Type.GetTypeFromProgID(PROGID_OPEN_PORT);
                    // Create instance that provides access to the properties of a port that has been opened in the firewall.
                    INetFwOpenPort port = Activator.CreateInstance(type) as INetFwOpenPort;
    
                    // Set properties for port
                    port.Name = name;
                    port.Port = portNo;
                    port.Scope = scope;
                    port.Protocol = protocol;
                    port.IpVersion = ipVersion;
    
                    // Add open port to windows firewall
                    manager.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(port);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    
        /// <summary>
        /// Set profiles for rule 
        /// </summary>
        /// <param name="name">Name of rule</param>
        /// <param name="profiles">bitmask value: 3 - public; 2 - private; 1 - domain</param>
        /// <returns></returns>
        public static bool SetProfilesForRule(string name, int profiles)
        {
            try
            {
                // Create the type from prog id
                Type typePolicy2 = Type.GetTypeFromProgID(PROGID_POLITCY2);
                // Create instance that allows an application or service to access the firewall policy.
                INetFwPolicy2 policy2 = Activator.CreateInstance(typePolicy2) as INetFwPolicy2;
    
                // Set profiles for rule                    
                policy2.Rules.Item(name).Profiles = profiles;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
