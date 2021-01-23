             var query = _mlsDashboardNavRepository.Table
            .OrderBy(x => x.Id)
            .Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                SubDashNav = _mlsSubDashNav.Table
                    .Where(s => s.DashId == x.Id)
            }).ToList().Select(q => new MLS_DashboardNavigation()
                                {
                                    Id = q.Id,
                                    Name = q.Name,
                                    Description = q.Description,
                                    ImageUrl = q.ImageUrl,
                                    SubDashNav = q.SubDashNav.ToList()
                                }).ToList();
            
            return query;
