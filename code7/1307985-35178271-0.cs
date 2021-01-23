    var proj = projContext.Projects.GetById("d7e63f89-47c0-e511-80d1-00155d4g5202");
    DraftProject checkoutProj = proj.CheckOut();
    projContext.Load(checkoutProj);
    projContext.Load(checkoutProj, p => p.Tasks.Include(t => t.Id, t => t.Work));
    projContext.ExecuteQuery();
    
    task.Work = "25";
    checkoutProj.Publish(true);
    projContext.ExecuteQuery();
