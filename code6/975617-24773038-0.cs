    collection.Update(
        Query.And(Query<ElcoRequest>.EQ(r => r.Id, newRequest.Id),
            Query<ElcoRequest>.EQ(r => r.Result, newRequest.Result)),
        Update<ElcoRequest>.PushAll(r => r.Equations, newRequest.Equations),
        UpdateFlags.Upsert);
