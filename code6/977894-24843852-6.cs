    using System;
    using System.Linq;
    using NetFwTypeLib;
    public sealed class NetFwAuthorizedApplication:
        INetFwAuthorizedApplication
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public NET_FW_SCOPE_ Scope { get; set; }
        public string RemoteAddresses { get; set; }
        public string ProcessImageFileName { get; set; }
        public NET_FW_IP_VERSION_ IpVersion { get; set; }
        public NetFwAuthorizedApplication ()
        {
            this.Name = "";
            this.Enabled = false;
            this.RemoteAddresses = "";
            this.ProcessImageFileName = "";
            this.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            this.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
        }
        public NetFwAuthorizedApplication (string name, bool enabled, string remoteAddresses, NET_FW_SCOPE_ scope, NET_FW_IP_VERSION_ ipVersion, string processImageFileName)
        {
            this.Name = name;
            this.Scope = scope;
            this.Enabled = enabled;
            this.IpVersion = ipVersion;
            this.RemoteAddresses = remoteAddresses;
            this.ProcessImageFileName = processImageFileName;
        }
        public static NetFwAuthorizedApplication FromINetFwAuthorizedApplication (INetFwAuthorizedApplication application)
        {
            return (new NetFwAuthorizedApplication(application.Name, application.Enabled, application.RemoteAddresses, application.Scope, application.IpVersion, application.ProcessImageFileName));
        }
    }
