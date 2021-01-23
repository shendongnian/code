    public static ProfileName GetIdentityName(this IIdentity identity)
    {
        if (identity == null)
            return null;
        var first = (identity as ClaimsIdentity).FirstOrNull(ClaimTypes.GivenName),
        var last = (identity as ClaimsIdentity).FirstOrNull(ClaimTypes.Surname)
        
        return string.Format("{0} {1}", first, last).Trim();
    }
    internal static string FirstOrNull(this ClaimsIdentity identity, string claimType)
    {
        var val = identity.FindFirst(claimType);
        return val == null ? null : val.Value;
    }
