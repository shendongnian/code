    _projectSites = (from de in _data.DataExchange
        join m in _data.Projects_MACO //combine exchange data and maco data
        on new
        {
            Number = de.number
        } equals
        new
        {
            Number = m.ProjectNumber == null ? m.OppNumber : m.ProjectNumber
        }
        join d in _data.DataStores //and select only sites with datastores
        on new
        {
            Number = de.number
        } equals
        new
        {
            Number = d.SiteNumber
        }
        where de.Server.Name == _server 
        && de.SiteType.Name != "opportunity" 
        && m.ProjectNumber != null
        select new ProjectSiteNode()
        {
            Server = de.Server.Name,
            ProjectNumber = de.number,
            Manager = m.ProjectNumber == null ? m.OMInitials : m.PMInitials,
            Exists = true,
            IsConfidential = de.confidential,
            Name = m.ProjectNumber == null ? m.OppTitle : m.ProjectTitle,
            ProjectType = de.SiteType.Name,// m.ProjectNumber == null ? "opportunity" : "project",
            Status = de.SiteState.Name
        }).Distinct().ToList();
