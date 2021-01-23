	.db.AuditEntities
		.Where(a => a.CaseID != null 
					&& a.CaseID != 0
					&& a.UserName == filterContext.HttpContext.User.Identity.Name)
		.GroupBy(a => a.CaseID)
		.OrderByDescending(grp => grp.Max(g => g.AuditEntityId))		
		.Take(5)
        .Select(a => a.FirstOrDefault())
		.ToList();
