    public void UpdateInstance(string scope, string query, string parametersJSON)
            {
                WindowsImpersonationContext impersonatedUser = WindowsIdentity.GetCurrent().Impersonate();
    
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                object result = serializer.Deserialize(parametersJSON, typeof(object));
    
                Dictionary<string, object> dic = (Dictionary<string, object>)result;
    
                ManagementObjectSearcher searcher;
                searcher = new ManagementObjectSearcher(scope, query);
    
                EnumerationOptions options = new EnumerationOptions();
                options.ReturnImmediately = true;
    
                foreach (ManagementObject m in searcher.Get())
                {
                    foreach (KeyValuePair<string, object> k in dic)
                    {
                        m.Properties[k.Key].Value = k.Value;
                    }
    
                    m.Put();
                }
            }
