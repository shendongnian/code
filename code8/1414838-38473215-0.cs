    public interface IRegistryService
    {
       bool createHkcuRegistry(string registryPath, string valueName, string value, RegistryValueKind valueKind = RegistryValueKind.String);
    }
    
    public class RegistryService : IRegistryService
    {
      public bool createHkcuRegistry(string registryPath, string valueName, string value, RegistryValueKind valueKind = RegistryValueKind.String)
      {
        try
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true);
            if (key != null)
            {
                key.SetValue(valueName, value, valueKind);
                key.Close();
    
            }
            else
            {
                RegistryKey newKey = Registry.CurrentUser.CreateSubKey(registryPath);
                newKey.SetValue(valueName, value, valueKind);
            }
            return true;
          }        
        }
    }
