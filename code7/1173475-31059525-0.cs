    using System.IO;
    using System.Reflection;
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Implemented - Returns the full path of the assembly file.
        /// </summary>
        public static string GetAssemblyPath(this Assembly Assemb)
        {
            string FileName = Assemb.CodeBase;
            if (FileName.Substring(0, 4).ToUpperInvariant() == "FILE")
                FileName = FileName.Remove(0, 8);
            return FileName;
        }
        /// <summary>
        /// Implemented - Returns the path to the folder where the assembly file is located
        /// </summary>
        public static string GetAssemblyFolder(this Assembly Assemb)
        {
            return Path.GetDirectoryName(GetAssemblyPath(Assemb));
        }
        /// <summary>
        /// Implemented - Combines the assembly folder with the passed filename, returning the full path of that file in the assmebly's folder.
        /// </summary>
        public static string GetFileInAssemblyFolder(this Assembly Assemb, string FileName)
        {
            return Path.Combine(GetAssemblyFolder(Assemb), FileName);
        }
        /// <summary>
        /// Implemented - Returns the full name of the embedded resources containing the passed string - Match case
        /// </summary>
        /// <param name="Assemb"></param>
        /// <param name="ResourceName"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetResourcesContainingString(this Assembly Assemb, string ResourceName)
        {
            return Assemb.GetManifestResourceNames().Where(S => S.Contains(ResourceName));
        }
        /// <summary>
        /// Implemented - Returns the full name of the first embedded resource containing the passed string - Match case
        /// </summary>
        /// <param name="Assemb"></param>
        /// <param name="ResourceName"></param>
        /// <returns></returns>
        public static string GetFirstResourceContainingString(this Assembly Assemb, string ResourceName)
        {
            return Assemb.GetResourcesContainingString(ResourceName).First();
        }
    }
