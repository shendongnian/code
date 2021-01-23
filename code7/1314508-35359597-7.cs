    Func<IQueryable<DataGroup>,IEnumerable<DataGroupViewModel>> GetDataGroupDTO = 
       d => d.Select(dt => new DataGroupViewModel 
       {
          DataGroup = dt;
          RecentDataElements = dt.DataElements.OrderByDescending(de => de.GeneratedDateTime)
           .FirstOrDefault();
       }
