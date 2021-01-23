    var pid=Guid.Parse(testP.Id);
    if (context.GetSet<PBM>().Any(l=>l.P.Id == pid) )
    {
        context.GetSet<PBM>()
               .Remove(context.GetSet<PBM>()
               .FirstOrDefault(l => l.P.Id == pid));
        context.SaveChanges();
    }
    
    if (context.GetSet<MOAH>().Any(l=>l.P.Id == pid))
    {
        context.GetSet<MOAH>()
               .Remove(context.GetSet<MOAH>()
               .FirstOrDefault(l => l.P.Id == pid));
        context.SaveChanges();
    }
