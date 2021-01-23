    public class IsrealVisibilityProvider : SiteMapNodeVisibilityProviderBase
    {
        public bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            return Constants.IsIsraeliIp;
        }
    }
