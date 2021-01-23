    public IEnumerable<ISiteMapNodeToParentRelation> GetSiteMapNodes(ISiteMapNodeHelper helper)
    {
        string sourceName = typeof(SiteMapNodeDto).Name;
        IEnumerable<SiteMapNodeDto> dtos = someExternalSource.GetNodes();
        foreach (var dto in dtos)
        {
            yield return helper.CreateNode(dto, sourceName);
        }
    }
