           if (namespaces.Count > 0)
            {
                if (namespaces.Contains("ComputerManagement10"))
                {
                    //use katmai+ namespace
                    wmiNamespaceToUse = wmiNamespaceToUse + "\\ComputerManagement10";
                }
                else if (namespaces.Contains("ComputerManagement"))
                {
                    //use yukon namespace
                    wmiNamespaceToUse = wmiNamespaceToUse + "\\ComputerManagement";
                }
                else if (namespaces.Contains("ComputerManagement11"))
                {
                    //use 2012 + namespace
                    wmiNamespaceToUse = wmiNamespaceToUse + "\\ComputerManagement11";
                }
                else if (namespaces.Contains("ComputerManagement12"))
                {
                    //use 2014 + namespace
                    wmiNamespaceToUse = wmiNamespaceToUse + "\\ComputerManagement12";
                }
                else
                {
                    wmiNamespaceToUse = string.Empty;
                }
            }
