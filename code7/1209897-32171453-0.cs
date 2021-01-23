        /// <summary>
        /// Gets whether the specified path is a UNC path or not.
        /// </summary>
        /// <param name="path">the path.</param>
        /// <returns>true if the path is a UNC path, otherwise false.</returns>
        public static bool IsUNCPath(
            string path)
        {
            try { return (new Uri(path)).IsUnc; }
            catch { return false; }
        }
        /// <summary>
        /// Gets a dictionary containing the mappings of each share's UNC path to its physical path on this PC.
        /// </summary>
        /// <returns>the dictionary containing the mappings.</returns>
        public static Dictionary<string, string> GetShareUNCPathToPhysicalPathMappings()
        {
            // Create a blank dictionary to hold the mappings.
            Dictionary<string, string> mappings = new Dictionary<string, string>();
            // Get this PC's host name.
            string hostName = Dns.GetHostName();
            // Get the registry key that contains the share information.
            using (RegistryKey shareKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\LanmanServer\Shares"))
            {
                // If the registry key isn't null...
                if (shareKey != null)
                {
                    // Get the share names and go through each one...
                    string[] shareNames = shareKey.GetValueNames();
                    foreach (string shareName in shareNames)
                    {
                        // Get the properties for the share and go through each one.
                        string[] shareProperties = (string[])shareKey.GetValue(shareName);
                        foreach (string shareProperty in shareProperties)
                        {
                            // Find the path property for the share and create the mapping.
                            if (shareProperty.StartsWith("Path="))
                            {
                                mappings[string.Format(@"\\{0}\{1}\", hostName, shareName)] = shareProperty.Remove(0, 5) + @"\";
                                break;
                            }
                        }
                    }
                }
            }
            // Return the mappings.
            return mappings;
        }
        /// <summary>
        /// Converts a UNC path to a physical path (note: the UNC path must correspond to a physical path on this PC).
        /// </summary>
        /// <param name="uncPath">the UNC path.</param>
        /// <returns>the physical path, or null if the UNC path doesn't correspond to a physical path on this PC.</returns>
        public static string ConvertUNCPathToPhysicalPath(
            string uncPath)
        {
            // If the supplied path isn't a UNC path, return null.
            if (!IsUNCPath(uncPath)) return null;
            // Attempt to find the physical path that the UNC path corresponds to.
            Dictionary<string, string> mappings = GetShareUNCPathToPhysicalPathMappings();
            foreach (string shareUNCPath in mappings.Keys)
            {
                if (uncPath.StartsWith(shareUNCPath))
                {
                    return mappings[shareUNCPath] + uncPath.Remove(0, shareUNCPath.Length);
                }
            }
            // If no mapping could be found, return null.
            return null;
        }
