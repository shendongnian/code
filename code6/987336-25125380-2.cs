    public static class Extensions
    {
        public static object TryGetProperty(this System.Management.ManagementObject wmiObj, string propertyName)
        {
            object retval;
            try
            {
                retval = wmiObj.GetPropertyValue(propertyName);
            }
            catch (System.Management.ManagementException ex)
            {
                retval = null;
            }
            return retval;
        }
    }
