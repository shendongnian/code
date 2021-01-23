    var projectSites = (from d in _data.DataStores
                                         join de in _data.DataExchange
                                         on new
                                         {
                                             Number = d.SiteNumber
                                         } equals
                                         new
                                         {
                                             Number = de.number
                                         }
                                         join m in _data.Projects_MACO //combine exchange data and maco data
                                         on new
                                         {
                                             Number = de.number,
                                             IsProject = de.SiteType.ID != 2
                                         } equals
                                         new
                                         {
                                             Number = m.ProjectNumber == null ? m.OppNumber : m.ProjectNumber,
                                             IsProject = m.ProjectNumber != null
                                         }
                                         where de.Server.Name == _server
                                         select new 
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
