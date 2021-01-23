    FieldInfo field = AppDomain.CurrentDomain.GetAssemblies()
                          .Where(n => n.GetType().Equals(typeof(SyncServiceInstaller)))
                          .FirstOrDefault()?.GetType()
                          .GetField("serviceInstaller1", BindingFlags.Instance 
                                                         | BindingFlags.Public 
                                                         | BindingFlags.NonPublic);
