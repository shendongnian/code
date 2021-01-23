    try
    {
        using (var database = new DbContext())
        {
            Member member = database.Members.Where(m=>m.ID=1).FirstOrDefault();
            member.Name = "NewMemberName";
            database.Entry(member).State = EntityState.Modified;
            database.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        using (var database = new DbContext())
        {
            database.Logs.Add(new Log() { Value=ex.ToString() });
            database.SaveChanges();
        }
    }
