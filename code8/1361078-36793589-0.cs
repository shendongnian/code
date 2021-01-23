    Project project = ctx.Projecten
       .Include(p => p.ProjectCategories.Select(s => s.Sub.Select(su => su.Sub)))
       .Include(p => p.ProjectCategories.Select(s => s.Categorie))
       .Find(p => p.ProjectId == projectId)
       .ToList();
