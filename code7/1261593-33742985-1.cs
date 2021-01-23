    public override int SaveChanges()
    {
        var auditChanges = ChangeTracker.Entries()
                .Where(t => t.State != EntityState.Unchanged && t.Entity.GetType().IsDefined(typeof(AuditAttribute),true))
                .Select(t =>
                {
                    var entityType = t.Entity.GetType();
                    if (entityType.BaseType != null && entityType.Namespace == "System.Data.Entity.DynamicProxies")
                    {
                        entityType = entityType.BaseType;
                    }
                    return new
                    {
                        entityType.Name,
                        State = t.State.ToString(),
                        Changes = t.State == EntityState.Deleted ? null : t.CurrentValues.PropertyNames
                            .Where(pn => t.State == EntityState.Added || t.CurrentValues[pn] == null && t.OriginalValues[pn] != null || t.CurrentValues[pn] != null && !(t.CurrentValues[pn].Equals(t.OriginalValues[pn])))
                            .ToDictionary(pn => pn, pn => t.CurrentValues[pn]),
                        Original = t.State == EntityState.Added ? null :
                            t.OriginalValues.PropertyNames.ToDictionary(pn => pn,
                                pn => t.OriginalValues[pn])
                    };
                });
        if (auditChanges.Any())
        {
            var auditMessage = new StringBuilder(2048);
            var changes = JsonConvert.SerializeObject(auditChanges, Formatting.Indented);
            auditMessage.AppendFormat("Timestamp: {0}\r\nUser: {1}\r\nIP Address: {2}\r\n====================\r\n{3}\r\n",
                DateTime.Now, HttpContext.Current == null || HttpContext.Current.User == null ? "" : HttpContext.Current.User.Identity.Name,
            Controllers.BaseController.GetIpAddress(HttpContext.Current),changes);
        NotificationManager.SendNotifications(NotificationType.Audit, this, GetDataSession(),null,auditMessage.ToString());
        }
        retval = base.SaveChanges();
    }
