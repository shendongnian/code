    // Names changed to be more idiomatic where feasible. We have no
    // idea what "sl" means.
    var query = from a in db.TableA
                join b in db.TableB
                  on new { a.WeekDay, a.StartTime, a.EndTime }
                  equals new { b.WeekDay, b.StartTime, b.EndTime }
                where a.Sl > b.Sl
                select ...;
