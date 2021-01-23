    public static class GetUserNameExUtil
    {
        #region Interop Definitions
        public enum EXTENDED_NAME_FORMAT 
        {
            NameUnknown = 0,
            NameFullyQualifiedDN = 1,
            NameSamCompatible = 2,
            NameDisplay = 3,
            NameUniqueId = 6,
            NameCanonical = 7,
            NameUserPrincipal = 8,
            NameCanonicalEx = 9,
            NameServicePrincipal = 10,
            NameDnsDomain = 12,
        }
        [System.Runtime.InteropServices.DllImport("secur32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetUserNameEx(int nameFormat, StringBuilder userName, ref int userNameSize);
        #endregion
        public static string GetUserName(EXTENDED_NAME_FORMAT nameFormat)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                return null;
            }
            StringBuilder userName = new StringBuilder(1024);
            int userNameSize = userName.Capacity;
            if (GetUserNameEx((int)nameFormat, userName, ref userNameSize) != 0)
            {
                string[] nameParts = userName.ToString().Split('\\');
                return nameParts[0];
            }
            return null;
        }
        public static string GetUserFullName()
        {
            return GetUserName(EXTENDED_NAME_FORMAT.NameDnsDomain);
        }
    }
