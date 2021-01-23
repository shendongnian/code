        var results =
            from u in users
            join a in alarms on u.UserID equals a.AssignedTo into ua
            select new
            {
                Fullname = u.FullName,
                Assigned = ua.Count(),
                Resolved = ua.Count(a => a.Resolved),
                Unresolved = ua.Count(a => !a.Resolved)
            };
            foreach (var r in results)
            {
                Console.WriteLine(r.Fullname + ", " + r.Assigned + ", " + r.Resolved + ", " + r.Unresolved);
            }
