    var res = tblClass
            .GroupBy(g=> g.ClassId)
            .Select(c =>
            {
                var rr = new ResultRow {Class = c.Key};
                foreach (var r in tblClass.GroupBy(gg=> gg.Student))
                {
                    rr.Students[r.Key] = "N";
                }
                foreach (var r in c.Where(w=> w.ClassId == c.Key))
                {
                    rr.Students[r.Student] = "Y";
                }
                return rr;
            })
            .toList();  //optional
