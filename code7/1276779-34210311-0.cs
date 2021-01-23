    [HttpPost, ActionName("_roleassignmentindex")]
    [ValidateAntiForgeryToken]
    public virtual ActionResult _RoleAssignmentIndex(RoleAssignmentFilterViewModel filter)
    {
        List<RoleAssignment> rolesAssmnt = null;
        if (filter.ProfileToSearch != null && filter.ProfileToSearch != Guid.Empty)
        {
            rolesAssmnt = db.RoleAssignment
                .Include(r => r.Assignee)
                .Include(r => r.OrganizationAssignedTo)
                .Where(r => r.IsActive &&
                    r.AssigneeId == filter.ProfileToSearch
                ).ToList();
            rolesAssmnt.AddRange(db.RoleAssignment
                .Include(r => r.AssigneeSnapshot)
                .Where(r => r.IsActive &&
                    r.AssigneeSnapshot.ProfileId == filter.ProfileToSearch
                ).ToList());
        }
        else
        {
            rolesAssmnt = db.RoleAssignment
                .Include(r => r.Assignee)
                .Include(r => r.OrganizationAssignedTo)
                .Where(r => r.IsActive
                ).ToList();
            rolesAssmnt.AddRange(db.RoleAssignment
                .Include(r => r.AssigneeSnapshot)
                .Where(r => r.IsActive
                ).ToList());
        }
        if (filter.RoleToSearch != null && filter.RoleToSearch > 0)
            rolesAssmnt = rolesAssmnt.Where(r => r.RoleId == filter.RoleToSearch).ToList();
        return View(rolesAssmnt);
    }
