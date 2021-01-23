    return from m in this.context.GB_Material
                           from v in this.context.WF_VideoVersion
                               .Where(
                                   v =>
                                       v.MaterialID == m.MaterialID)
                               .DefaultIfEmpty()
                           select new MaterialSearchResult
                           {
                               MaterialId = m.MaterialID,
                               MaterialName = m.MaterialName,
                               MaterialTitle = m.MaterialTitle,
                               CreatedDate = m.CreatedDate,
                               NearestTxDate = v.NearestTXDate,
                               Channel = v.ScheduleName
                           };
