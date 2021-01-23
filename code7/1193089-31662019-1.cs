    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int Native_GetConfigParamCallBackMethodDelegate(
        string paramName,
        [MarshalAs(UnmanagedType.BStr)] ref string paramValue
        );
    static int GetConfigParamCallBackWrapper(
        string paramName, 
        ref string paramValue
        )
    {
        string valueTemp = // Fetch the string value here
        if (valueTemp == null)
        {
            return 0;
        }
        paramValue = valueTemp;
        return 1;
    }
