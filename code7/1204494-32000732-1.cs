    var result=MultiMerger.TargetIds
        .Select(id =>
        {
            FileDatabaseMerger merger = MultiMerger.GetMerger(id);
    
            return new
            {
                Id = id,
                IsStale = merger.TargetIsStale,
                // ...
            };
        })
        .ToList();
    fileUpdatesGridView.DataSource = result;
    fileUpdatesGridView.DataBind();
    fileUpdatesMergeButton.Enabled = result.Any(r=>r.IsStale);
