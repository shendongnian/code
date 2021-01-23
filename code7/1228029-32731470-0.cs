     bool DeleteRecordFromDns(string ZoneName, string dnsServerName, string recordName)
        {
            try
            {
                string Query = string.Format("SELECT * FROM MicrosoftDNS_AType WHERE OwnerName = '{0}.{1}'", recordName, ZoneName);
                ObjectQuery qry = new ObjectQuery(Query);
                ManagementScope scope = new ManagementScope(@"\\" + dnsServerName + "\\root\\MicrosoftDNS");
                scope.Connect();
                ManagementObjectSearcher s = new ManagementObjectSearcher(scope, qry);
                ManagementObjectCollection col = s.Get();
                if (col.Count > 0)
                {
                    foreach (ManagementObject obj in col)
                    {
                        obj.Delete();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
