    public static IEnumerable<Speaker> ByTenant(this IEnumerable<Speaker> source, string tenantName)
        {
            return source
                   .Where(speaker => speaker.Sessions.Any(a => a.TenantName == tenantName));
        }
