    static int GetConfigParamCallBackWrapper(
        string paramName, 
	    IntPtr paramValue)
    {
       string valueTemp = // Acquire valueTemp here. 
        IntPtr sPtr = Marshal.StringToHGlobalAnsi(valueTemp);
        try
        {
            // Create a byte array to receive the bytes of the unmanaged string
            var sBytes = new byte[valueTemp.Length + 1];
            // Copy the the bytes in the unmanaged string into the byte array
            Marshal.Copy(sPtr, sBytes, 0, valueTemp.Length);
            // Copy the bytes from the byte array into the buffer passed into this callback
            Marshal.Copy(sBytes, 0, paramValue, sBytes.Length);
            // Free the unmanaged string
        }
        finally 
        {
            Marshal.FreeHGlobal(sPtr);
        }
