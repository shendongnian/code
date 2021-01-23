    public static string GetGroupId(this ClaimsPrincipal principal)
    {
        var groupIdClaim = principal.Claims.FirstOrDefault(c => c.Type == "MyApplication:GroupClaim");
        if (personIdClaim != null)
        {
            return groupIdClaim.Value;
        }
        return String.Empty;
    }
