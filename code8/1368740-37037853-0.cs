    public static IAuthTokens GetOAuthTokens(this IAuthSession session, string provider)
    {
        foreach (var tokens in session.ProviderOAuthAccess)
        {
            if (string.Compare(tokens.Provider, provider, StringComparison.InvariantCultureIgnoreCase) == 0)
                return tokens;
        }
        return null;
    }
