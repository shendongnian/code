    public class ADHelper {
        public static PrincipalContext CreatePrincipalContext(string domain = null) {
            string container = null;
            if (IsNullOrWhiteSpace(domain)) {
                domain = GetCurrentDnsSuffix();
                if (domain != null && domain.EndsWith(".com", StringComparison.InvariantCultureIgnoreCase)) {
                    container = GetContainers(domain);
                } else {
                    domain = null;
                }
            }
    
            var hostName = GetHostName();
            if (IsNullOrWhiteSpace(domain)) {
                domain = hostName;
            }
    
            ContextType contextType;
            if (domain.Equals(hostName, StringComparison.InvariantCultureIgnoreCase) &&
                domain.Equals(Environment.MachineName, StringComparison.InvariantCultureIgnoreCase)) {
                contextType = ContextType.Machine;
            } else {
                contextType = ContextType.Domain;
            }
    
            PrincipalContext principalContext = null;
            if (contextType == ContextType.Machine) {
                principalContext = new PrincipalContext(contextType, domain);
            } else {
                principalContext = new PrincipalContext(contextType, domain, container, Constants.LDAPUser, Constants.LDAPPassword);
            }
    
            return principalContext;
        }
    
        public static string GetCurrentDnsSuffix() {
            string dnsHostName = null;
            if (NetworkInterface.GetIsNetworkAvailable()) {
                var nics = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(ni => ni.OperationalStatus == OperationalStatus.Up);
    
                foreach (var ni in nics) {
                    var networkConfiguration = ni.GetIPProperties();
    
                    var dnsSuffix = networkConfiguration.DnsSuffix;
                    if (dnsSuffix != null) {
                        dnsHostName = dnsSuffix;
                        break;
                    }
    
                    var address = networkConfiguration.DnsAddresses.FirstOrDefault();
                    if (address != null) {
                        try {
                            var dnsHost = Dns.GetHostEntry(address.ToString());
                            dnsHostName = dnsHost.HostName;
                        } catch (System.Net.Sockets.SocketException e) {
                            traceError(e);
                        } catch (Exception e) {
                            traceError(e);
                        }
                    }
                }
            }
            return dnsHostName;
        }
    
        private static string GetContainers(string ADServer) {
            string[] LDAPDC = ADServer.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < LDAPDC.GetUpperBound(0) + 1; i++) {
                LDAPDC[i] = string.Format("DC={0}", LDAPDC[i]);
            }
            String ldapdomain = Join(",", LDAPDC);
            return ldapdomain;
        }
        public static string GetHostName() {
            var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            return ipProperties.HostName;
        }
    }
