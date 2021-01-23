    public static bool IsFullyTrusted()
    {
        try
        {
            new PermissionSet(PermissionState.Unrestricted).Demand();
            return true;
        }
        catch (SecurityException)
        {
            return false;
        }
    }
