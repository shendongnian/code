    [HttpPost, ActionName("_roleassignmentindex")]
    [ValidateAntiForgeryToken]
    public virtual ActionResult _RoleAssignmentIndex(RoleAssignmentFilterViewModel filter)
    {
        List<RoleAssignment> = null;
    
        if (filter.ProfileToSearch != null && filter.ProfileToSearch != Guid.Empty)
        {
           rolesAssmnt = db.RoleAssignment
            .Include(r => r.Assignee)
            .Include(r => r.AssigneeSnapshot)
            .Where(r => r.IsActive && r.AssigneeId == filter.ProfileToSearch)
            .ToList();
            
           rolesAssmnt.AddRange(db.RoleAssignment
            .Include(r => r.Assignee)
            .Include(r => r.OrganizationAssignedTo)
            .Where(r => r.IsActive && r.AssigneeId == filter.ProfileToSearch));            
        }
    
        else if (filter.RoleToSearch != null && filter.RoleToSearch > 0)
        {
           rolesAssmnt = db.RoleAssignment
            .Include(r => r.Assignee)
            .Include(r => r.AssigneeSnapshot)
            .Where(r => r.IsActive && r.RoleId == filter.RoleToSearch)
            .ToList();
            
           rolesAssmnt.AddRange(db.RoleAssignment
            .Include(r => r.Assignee)
            .Include(r => r.OrganizationAssignedTo)
            .Where(r => r.IsActive && r.RoleId == filter.RoleToSearch));
        }
    
        return View(rolesAssmnt);
    }
