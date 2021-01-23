	var result = (from t in db.Task
             join r in db.EmpTask
                          .GroupBy(i => i.TaskID)
                          .Select(i => new { TaskID = i.Key, EmpTaskId = i.Max(t => t.ID)})
                      on t.ID equals r.TaskID
             join et in db.EmpTask on r.EmpTaskId equals et.ID
             select new
             {
                ID = t.ID,
                Title = t.Title,
                XXXX = et.XXXX
             }).ToList();
