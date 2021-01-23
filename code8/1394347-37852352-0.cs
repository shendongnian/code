    public SystemAccessList GetAccessList(SystemAccessList systemAccessList)
    {
            var qresult = db.tbl_SystemAccessList
                    .GroupBy(g => g.ClassID)
                    .AsEnumerable().Select(c =>
                    {
                        var rr = new ResultRow { Class = c.Key };
                        foreach (var r in db.tbl_SystemAccessList.GroupBy(gg => gg.StudentID))
                        {
                            rr.Student[r.Key] = "N";
                        }
                        foreach (var r in c.Where(w => w.ClassID == c.Key))
                        {
                            rr.Student[r.StudentID] = "Y";
                        }
                        return rr;
                    }).ToList();
            systemAccessList.SystemAccessList.AddRange(qresult);
            return systemAccessList;
        }
