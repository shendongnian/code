    private static ILocator RecreateLocator(ILocator locator, CloudMediaContext mediaContext)
            {
                // Save properties of existing locator.
                var asset = locator.Asset;
                var accessPolicy = locator.AccessPolicy;
                var locatorId = locator.Id;
                var startDate = locator.StartTime;
                var locatorType = locator.Type;
                var locatorName = locator.Name;
     
                // Delete old locator.
                locator.Delete();
     
                if (locator.ExpirationDateTime <= DateTime.UtcNow)
                {
                    throw new Exception(String.Format(
                        "Cannot recreate locator Id={0} because its locator expiration time is in the past", 
                        locator.Id));
                }
     
                // Create new locator using saved properties.
                var newLocator = mediaContext.Locators.CreateLocator(
                    locatorId,
                    locatorType,
                    asset,
                    accessPolicy,
                    startDate,
                    locatorName);
     
                Trace.TraceInformation("Locator created. Name={0}, path={1}", newLocator.Name, newLocator.Path);
     
                return newLocator;
            }
