          if (cacheKey.ConcreteType != null)
                {
                    try
                    {
                        newLogger.Initialize(cacheKey.Name, this.GetConfigurationForLogger(cacheKey.Name, this.Configuration), this);
                    }
                    catch (Exception ex)
                    {
                        if(ThrowExceptions && ex.MustBeRethrown())
                        throw;
                    }
                }
