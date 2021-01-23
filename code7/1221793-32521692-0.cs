    var missingOrNewObjs = from newobj in ObjsList
                           join existing in db.Objs
                           on new { newobj.Name, newobj.Number, newobj.Address }
                           equals new { existing.Name, existing.Number, existing.Address } into grpJoin
                           from outerjoin in grpJoin.DefaultIfEmpty()
                           where outerjoin == null
                           select newobj;
    db.Objs.AddRange(missingOrNewObjs);
