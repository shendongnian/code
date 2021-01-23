    public static bool CanEdit(this IIdentity identity)
    {  
         return identity.IsAuthenticated
            && identity is ClaimsIdentity
            && ((ClaimsIdentity)identity).HasClaim(x =>
                x.Type == "EditClaim" && x.Value == "true");
    }
