        public static bool IsWindowsPhone8x()
        {
            try
            {
                Version version = System.Environment.OSVersion.Version;
                return version.Major > 8 ? false : true;
            }
            catch (Exception)
            {
                return false;
            }
        }
