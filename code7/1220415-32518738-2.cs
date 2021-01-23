            var pagedUnamendedViolationList = ViolationService.GetViolationByModule(new PagedRequest() { Page = page, PageSize = pageSize },
                moduleId,
                stakeholderId,
                v => (fUser == null || v.ControlPoint.Area.FronendUsers.Contains(fUser)) && !v.IsAmended,
                "ControlPoint.Area.AreaName DESC" 
                );
