    private static void ParameterSubstitution(string[] testName, string[] testNotification, ref string url)
    {
        const string firstParametrName = "name";
        const string secondParametrName = "lastNotificationID";
        // first parametr
        url += string.Format("?{0}={1}", firstParametrName, string.Join(string.Format("&{0}=", firstParametrName), testName));
        // second parametr
        url += string.Format("&{0}={1}", secondParametrName, string.Join(string.Format("&{0}=",secondParametrName), testNotification));
    }
