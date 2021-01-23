    protected override Dictionary<string, bool> GetValidSearchProperties()
            {
                Dictionary<string, bool> searchProperties = base.GetValidSearchProperties();
                if (!searchProperties.ContainsKey("AccessibleName"))
                    searchProperties.Add("AccessibleName", true);
                return searchProperties;
            }
