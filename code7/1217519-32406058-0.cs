    using (var context = new Cde_Entities())
    {
        var instanceA = context.A.SingleOrDefault(x => x.AId == aid);
        var first = context.Entry(instanceA).Collection(x => x.B).Query().OrderBy(x => x.BId).FirstOrDefault();
        var last = context.Entry(instanceA).Collection(x => x.B).Query().OrderByDescending(x => x.BId).FirstOrDefault();
        instanceA.First = first;
        instanceA.Last = last;
        return instanceA;
    }
