      var test = from m in Database.Messages
                 where !m.IsDeleted && (m.ToID == User.ID || m .FromID == User.ID)
                 orderby m.ID descending
                 let otherEnd = m.ToID == userId ? m.FromID : m.ToID
                 group m by otherEnd into g
			     select new { g.Key, g.OrderByDescending(n => n.ID).FirstOrDefault() };
