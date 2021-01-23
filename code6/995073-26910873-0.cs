    var useInsertQuery = from o in db.OtherObjs
                join m in db.MyObjs on new { m.TeamId, m.PlayerId } equals new { o.TeamId, o.PlayerId } into moJoin
                from mo in moJoin.DefaultIfEmpty()
                let useInsert = (mo == null)
                // MyObj f(OtherObj otherObj) creates your updated MyObj value
                group f(m,o) by useInsert into g;
    var useInsertDictionary = useInsertQuery.ToDictionary(g => g.Key, g => g.ToArray());
    MyObj[] objs;
    if (useInsertDictionary.TryGetValue(true, out objs))
        db.InsertBatch(objs);
    if (useInsertDictionary.TryGetValue(false, out objs))
        db.Update(objs);
