    [System.Security.SecuritySafeCritical]  // auto-generated
    private void Dispose(bool disposing) {
          if (hkey != null) {
               if (!IsSystemKey()) {
                  try {
                      hkey.Dispose();
                    }
                    catch (IOException){
                        // we don't really care if the handle is invalid at this point
                    }
                    finally
                    {
                        hkey = null;
                    }
                }
                else if (disposing && IsPerfDataKey()) {
                SafeRegistryHandle.RegCloseKey(RegistryKey.HKEY_PERFORMANCE_DATA);
                }  
          }
    }
