      var query = session.Query<Project>()
                .Where(r=>r.IsActive)
                .FetchMany(r => r.ProjectDependencies)
                .ThenFetch(r => r.DependencyProject);
      query.ThenFetch(r => r.Owner).ToFuture();
      query.ThenFetch(r => r.Status).ToFuture();
      Project project = query.ToFuture().ToList();
