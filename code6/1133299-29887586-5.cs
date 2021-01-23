    private void btnWillPassApplicabilityRules_Click(object sender, EventArgs e)
    {
        XDocument doc = XDocument.Load("msu.xml");
        var elements = doc.Element("Updates").Elements("ApplicabilityRules").Elements("IsInstalled").Elements();
    
        foreach (var element in elements) {
            if (element.ToString().StartsWith("<b.RegSz")) {
                string subKeyName = element.Attribute("Subkey").Value;
                string keyName = element.Attribute("Value").Value;
                string keyValue = element.Attribute("Data").Value;
    
                //TODO: Leave the Registry Hive "Switch()" upto reader to fully implement
                if (!ValueExistsInRegistry(Registry.LocalMachine, subKeyName, keyName, keyValue)) {
                    Console.WriteLine("Install is not applicable as Applicability Rule failed: " + element.ToString());
                    return;
                }
            }
            else if (element.ToString().StartsWith("<b.WmiQuery")) {
                string nameSpace = element.Attribute("Namespace").Value;
                string wqlQuery = element.Attribute("WqlQuery").Value;
                if (!ValueExistsInWMI(nameSpace, wqlQuery)) {
                    Console.WriteLine("Install is not applicable as Applicability Rule failed: " + element.ToString());
                    return;
                }
            }
        }
    }
    
    private bool ValueExistsInRegistry(RegistryKey root, string subKeyName, string keyName, string keyValue)
    {
        using (RegistryKey key = root.OpenSubKey(subKeyName)) {
            if (key != null) {
                return keyValue == key.GetValue(keyName).ToString();
            }
        }
        return false;
    }
    
    private bool ValueExistsInWMI(string nameSpace, string query)
    {
        ManagementScope Scope;
        Scope = new ManagementScope(String.Format("\\\\{0}\\" + nameSpace, "."), null);
        Scope.Connect();
        ObjectQuery Query = new ObjectQuery(query);
        ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
        if (Searcher.Get().Count == 0) {
            return false;
        }
        else {
            return true;
        }
        return false;
    }
    }
