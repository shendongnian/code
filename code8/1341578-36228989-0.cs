    foreach (var item in project.JobInProjects)
    {
        db.Entry(item.Job).State = EntityState.Deleted;
        db.Entry(item).State = EntityState.Deleted; // <= line added
    }
