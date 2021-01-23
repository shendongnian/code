    FieldInfo field = AppDomain.CurrentDomain.GetAssemblies()
                          .FirstOrDefault(n => n.GetType().Equals(typeof(SyncServiceInstaller)))?.GetType()
                          .GetField("serviceInstaller1", BindingFlags.Instance 
                                                         | BindingFlags.Public 
                                                         | BindingFlags.NonPublic);
