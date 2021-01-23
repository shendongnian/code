    Expressions<Func<DataGroup,DataGroupViewModel>> GetDataGroupDTO = 
       d => new DataGroupViewModel 
       {
          DataGroup = d;
          RecentDataElements = d.DataElements.OrderByDescending(de => de.GeneratedDateTime)
           .FirstOrDefault();
       }
