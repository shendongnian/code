                (from p in orgSvcContext.AsyncOperationSet.AsEnumerable()
                 where p.PrimaryEntityType == entityLogicalName
                       && p.RegardingObjectId.Id == regardingObjectId
                       && p.Name == processName
                       && p.StatusCode.Value == 10 
                 select new AsyncOperation { Id = p.Id, StateCode = p.StateCode, StatusCode = p.StatusCode })
