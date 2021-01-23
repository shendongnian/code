    public IEnumerable<ContentItem> GetUntranslatedTenants(int cultureId)
    {
        var allTenants = _contentManager.Query().ForType("MyTenant").List();
        var untranslatedTenants = allTenants
        .Where(x => x.As<LocalizationPart>().MasterContentItem == null &&
            !allTenants.Any(y => y.As<LocalizationPart>().MasterContentItem == x &&
            y.As<LocalizationPart>().Culture.Id == cultureId));
        return untranslatedTenants;
    }
