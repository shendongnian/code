    var projectId= 2; // replace with a valid projectID value
    var workersNotInProject = db.Worker.Where(c => !(db.RetaleTbl
                                      .Where(s => s.IDProject== projectId)
                                      .Select(d => d.IDWorker))
                             .Contains(c.ID)).ToList();
