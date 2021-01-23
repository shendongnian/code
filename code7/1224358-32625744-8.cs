    public static SiteMapNodeProviderExtensions
    {
        public static ISiteMapToParentRelation CreateNode(this ISiteMapNodeHelper helper, SiteMapNodeDto dto, string sourceName)
        {
             string key = helper.CreateNodeKey(
                dto.ParentKey,
                dto.Key,
                dto.Url,
                dto.Title,
                dto.Area,
                dto.Controller, 
                dto.Action, 
                dto.HttpMethod,
                dto.Clickable);
            var nodeParentMap = helper.CreateNode(key, attribute.ParentKey, sourceName);
            var node = nodeParentMap.Node;
            node.Title = title;
            
            // Populate remaining properties...
            return nodeParentMap;
        }
    }
