    using Microsoft.Win32;
    private static int ReadRegistryIntValue(string sSubKey, string sKeyName)
    {
    	try
    	{
    		int retValue = 0;
    		RegistryKey rkSearchFor = Registry.LocalMachine.OpenSubKey(sSubKey);
    		if (rkSearchFor == null)
    		{
    			return retValue;
    		}
    		else
    		{
    			try
    			{
    				retValue = Convert.ToInt32(rkSearchFor.GetValue(sKeyName));
    			}
    			catch (Exception)
    			{
    				return 0;
    			}
    			finally
    			{
    				rkSearchFor.Close();
    				rkSearchFor.Dispose();
    			}
    		}
    		return retValue;
    	}
    	catch (Exception)
    	{
    		return 0;
    	}
    }
   
