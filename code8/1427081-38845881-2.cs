    var results = from wb in workbasketitems
                  join wft in workflowtasks on wb.TaskId equals wft.TaskId
                  join wg in workgroup on wb.WorkGroupId equals wg.WorkGroupId
                  join au in applicationuser on wb.ActionUserId equals au.AUId into wbl
                  from auList in wbl.DefaultIfEmpty(new { AUId = wb.ActionUserId, AUDesc = "Blank" } )
                  select new { wft.TaskDesc, wg.WGDesc, Desc = auList.AUDesc, wb.Work };
