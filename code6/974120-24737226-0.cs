        public static Version GetExecutingAssemblyVersion()
        {
            var ver = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            // read what's defined in [assembly: AssemblyFileVersion("1.2.3.4")]
            return new Version(ver.ProductMajorPart, ver.ProductMinorPart, ver.ProductBuildPart, ver.ProductPrivatePart);
        }
