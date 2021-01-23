    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using ActiveDs; // Namespace added via ref to C:\Windows\System32\activeds.tlb
    
    private DateTime? getLastLogin(DirectoryEntry de)
    {
        Int64 lastLogonThisServer = new Int64();
    
        if (de.Properties.Contains("lastLogon"))
        {
            if (de.Properties["lastLogon"].Value != null)
            {
                try
                {
                    IADsLargeInteger lgInt =
                    (IADsLargeInteger) de.Properties["lastLogon"].Value;
                    lastLogonThisServer = ((long)lgInt.HighPart << 32) + lgInt.LowPart;
    
                    return DateTime.FromFileTime(lastLogonThisServer);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        return null;
    }
