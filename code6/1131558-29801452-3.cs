    using (var ctx = new MyModelName())
    {
        var User = (some linq query using ctx).FirstOrDefault();
        object.LastLoginDT = DateTime.Now;
        object.TermsnCondAcceptDtID = 14;
        object.TermsnCondAcceptDt = DateTime.Now;
        updateInfo(object, ctx);
    }
    private static void updateInfo(tableUserAccount object, MyModelName ctx)
    {
        ctx.Add(object);
        ctx.SaveChanges();
    }
