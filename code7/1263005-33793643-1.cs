            var query = DashboardNavRepository.Table
            .OrderBy(x => x.Id)
            .Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                SubDashNav = _SubDashNav.Table
                    .Where(s => s.DashId == x.Id)
                    .Select(y => new { Id = y.Id, DashId = y.DashId, Name = y.Name, Description = y.Description, ImageUrl = y.ImageUrl, IsAdvanced = y.IsAdvanced }).ToList()
            }).ToList().Select(q => new DashboardNavigation()
                                {
                                    Id = q.Id,
                                    Name = q.Name,
                                    Description = q.Description,
                                    ImageUrl = q.ImageUrl,
                                    SubDashNav = q.SubDashNav.Select(r => new SubNav() { Id = r.Id, DashId = r.DashId, Name = r.Name, Description = r.Description, ImageUrl = r.ImageUrl, IsAdvanced = r.IsAdvanced }).ToList()
                                }).ToList();
            
            return query;
