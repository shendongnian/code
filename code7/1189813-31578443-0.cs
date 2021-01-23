     public static IQueryable GetTree_CAOC(UserCredential credential)
        {
            VantageDataContext db = new VantageDataContext();
            if (credential.DistributorUID.HasValue)
            {
                int DistributorUID = credential.DistributorUID.Value;
                List<int> fullCatUIDList = new List<int>();
                List<int> catUIDList = new List<int>();
                List<int> dupCatUIDList = new List<int>();
                var categoryUID5s = (from di in db.DistributorOutlets
                                     join o in db.Outlets on di.OutletUID equals o.UID
                                     where di.DistributorUID == DistributorUID
                                          && o.OutletCategory5UID != null
                                     select new
                                     {
                                         CategoryUID = o.OutletCategory5UID
                                     }
                                     ).Distinct();
                foreach (var categoryUID5 in categoryUID5s)
                {
                    int uid = (int)categoryUID5.CategoryUID;
                    if (!catUIDList.Contains(uid))
                        catUIDList.Add(uid);
                    if (!fullCatUIDList.Contains(uid))
                        fullCatUIDList.Add(uid);
                }
                bool flag = true;
                while (flag)
                {
                    dupCatUIDList.Clear();
                    dupCatUIDList.AddRange(catUIDList);
                    var cats = from ca in db.OutletCategories
                               where dupCatUIDList.Contains(ca.UID)
                                && ca.ParentUID != null
                               select new { ca.ParentUID };
                    catUIDList.Clear();
                    foreach (var cat in cats)
                    {
                        int uid = (int)cat.ParentUID;
                        if (!catUIDList.Contains(uid))
                            catUIDList.Add(uid);
                        if (!fullCatUIDList.Contains(uid))
                            fullCatUIDList.Add(uid);
                    }
                    if (catUIDList.Count == 0)
                        flag = false;
                }
                var result = from oc in db.OutletCategories
                             orderby oc.Depth, oc.Description
                             where fullCatUIDList.Contains(oc.UID)
                                && oc.ExpiryDate == null
                             select new
                             {
                                 oc.UID,
                                 oc.Description,
                                 oc.ParentUID,
                                 oc.Depth
                             };
                return result;
            }
            else
            {
                var result = from oc in db.OutletCategories
                             orderby oc.Depth, oc.Description
                             where oc.ExpiryDate == null
                             select new
                             {
                                 oc.UID,
                                 oc.Description,
                                 oc.ParentUID,
                                 oc.Depth
                             };
                return result;
            }
        }  
