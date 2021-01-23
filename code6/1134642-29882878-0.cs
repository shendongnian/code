        elements = from i in db.ProjectAccessTypes
                    select new ProjectMemberUserRolesElementViewModel()
                    {
                        AccessType = i.Type,
                        Create = i.ProjectMemberAccess.Where(p => p.ProjectMemberID == ProjectMemberID).Select(p => p.Create).FirstOrDefault(),
                        Delete = i.ProjectMemberAccess.Where(p => p.ProjectMemberID == ProjectMemberID).Select(p => p.Delete).FirstOrDefault(),
                        Edit = i.ProjectMemberAccess.Where(p => p.ProjectMemberID == ProjectMemberID).Select(p => p.Edit).FirstOrDefault(),
                        Read = i.ProjectMemberAccess.Where(p => p.ProjectMemberID == ProjectMemberID).Select(p => p.Read).FirstOrDefault()
                    };
