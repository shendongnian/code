     public IEnumerable<GroupModel> GetAllSupplierClaimGroupsByClientGrouping(int ClientID) {
    
                var x = (from g in camOnlineDb.Group
                         where g.ClientID == 1
                         group g by new { GroupID = g.GroupID, GroupName = g.GroupName }
                             into a
                             select new GroupModel{ GroupID = a.Key.GroupID, GroupName = a.Key.GroupName });
                return x.OrderBy( r=> r.GroupName);
            }
