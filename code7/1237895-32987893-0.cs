    var result = from t in conn.TICKETS
                 join dept in conn.DEPARTMENT on t.FK_DEPT_ID equals dept.PK_DEPT_ID
                 select new { DeptName = dept.NAME, Status = t.STATUS }
                 into temp
                 group temp by new { temp.DeptName, temp.Status }
                 into g
                 select new { g.Key.DeptName, g.Key.Status, Count = g.Count()};
