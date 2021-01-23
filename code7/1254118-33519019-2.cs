    var AppErrors=from AE in _db.ApplicationErrors select AE;
    var LogErrors=from LE in _dc.LogErrors select LE;
    var internerrors=AppErrors.Union(LogErrors);
    var InternalErrors=(from ie in internerrors select new InternalErrors()
                          {
                              ID=ie.ID,
                              Message=ie.ApplicationMessage,
                              Name=ie.ApplicationName,
                              Date=ie.ApplicationDate
                          }).ToList();
