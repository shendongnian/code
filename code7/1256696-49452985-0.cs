    static void Main(string[] args)
        {
            string EdgeVersion = string.Empty;
            //open the registry and parse through the keys until you find Microsoft.MicrosoftEdge
            RegistryKey reg = Registry.ClassesRoot.OpenSubKey(@"Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Packages");
            if (reg != null)
            {
                foreach (string subkey in reg.GetSubKeyNames())
                {
                    if (subkey.StartsWith("Microsoft.MicrosoftEdge"))
                    {
                        //RegEx: (Microsoft.MicrosoftEdge_)(\d +\.\d +\.\d +\.\d +)(_neutral__8wekyb3d8bbwe])
                        Match rxEdgeVersion = null;
                        rxEdgeVersion = Regex.Match(subkey, @"(Microsoft.MicrosoftEdge_)(?<version>\d+\.\d+\.\d+\.\d+)(_neutral__8wekyb3d8bbwe)");
                        //just after that value, you need to use RegEx to find the version number of the value in the registry
                        if ( rxEdgeVersion.Success )
                            EdgeVersion = rxEdgeVersion.Groups["version"].Value;
                    }
                }
            }
            Console.WriteLine("Edge Version(empty means not found): {0}", EdgeVersion);
            Console.ReadLine();
        }
