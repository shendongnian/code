    var lastItems = baseController.db.AuditEntities                                 
                                 .GroupBy(a => a.CaseID)
                                 .Select(a => a.FirstOrDefault())
                                 .Where(a => a.CaseID != null && a.CaseID != 0)
                                 .Where(a => a.UserName == filterContext.HttpContext.User.Identity.Name)
                                 .OrderByDescending(a => a.AuditEntityId)
                                 .Take(5)
                                 .ToList();
