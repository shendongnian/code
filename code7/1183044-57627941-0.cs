public static string GetUserEmailAddressFromVisualStudioRegistry()
{
    try
    {
        const string ConnectedUserSubKey = @"Software\Microsoft\VSCommon\ConnectedUser";
        const string EmailAddressKeyName = "EmailAddress";
        RegistryKey connectedUserSubKey = Registry.CurrentUser.OpenSubKey( ConnectedUserSubKey );
        string[] subKeyNames = connectedUserSubKey?.GetSubKeyNames();
        if ( subKeyNames == null || subKeyNames.Length == 0 )
        {
            return null;
        }
        int[] subKeysOrder = new int[subKeyNames.Length];
        for ( int i = 0; i < subKeyNames.Length; i++ )
        {
            Match match = Regex.Match( subKeyNames[i], @"^IdeUser(?:V(?<version>\d+))?$" );
            if ( !match.Success )
            {
                subKeysOrder[i] = -1;
                continue;
            }
            string versionString = match.Groups["version"]?.Value;
            if ( string.IsNullOrEmpty( versionString ) )
            {
                subKeysOrder[i] = 0;
            }
            else if ( !int.TryParse( versionString, out subKeysOrder[i] ) )
            {
                subKeysOrder[i] = -1;
            }
        }
        Array.Sort( subKeysOrder, subKeyNames );
        for ( int i = subKeyNames.Length - 1; i >= 0; i++ )
        {
            string cacheSubKeyName = $@"{subKeyNames[i]}\Cache";
            RegistryKey cacheKey = connectedUserSubKey.OpenSubKey( cacheSubKeyName );
            string emailAddress = cacheKey?.GetValue( EmailAddressKeyName ) as string;
            if ( !string.IsNullOrWhiteSpace( emailAddress ) )
            {
                return emailAddress;
            }
        }
    }
    catch
    {
        // Handle exceptions here if it's wanted.
    }
    return null;
}
This algorithm tries all versions from the newest one and then all other siblings. It returns null in case of a failure.
