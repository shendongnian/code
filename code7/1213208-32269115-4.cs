    public static bool CanEdit(this IIdentity identity)
    {
         var claims= identity as ClaimsIdentity;
         
        
         return identity.IsAuthenticated
            && identity is ClaimsIdentity
            && ((ClaimsIdentity)identity).HasClaim(x =>
                x.Type == "EditClaim" && x.Value == "true");
    }
