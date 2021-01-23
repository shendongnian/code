        var results =
            from u in users
            join a in alarms on u.UserID equals a.AssignedTo into ua
            select new
            {
                Fullname = u.FullName,
                Assigned = ua.Count(al => al.AssignedTo == u.UserID),
                Resolved = ua.Count(al => al.Resolved),
                Unresolved = ua.Count(al => al.AssignedTo == u.UserID) - ua.Count(al => al.Resolved)
            }.Distinct();
