    public class MyEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var identity = Thread.CurrentPrincipal.Identity;
            if (identity is ExternalIdentity)
            {
                var externalIdentity = Thread.CurrentPrincipal.Identity as ExternalIdentity;
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Principal", new {
                    externalIdentity.Key,
                    externalIdentity.RequestId
                }, true));
            }
            else
            {
                var userIdentity = Thread.CurrentPrincipal.Identity as UserIdentity;
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Principal", new {
                    userIdentity.FullName,
                    userIdentity.OrganizationName
                }, true));
            }
        }
    }
