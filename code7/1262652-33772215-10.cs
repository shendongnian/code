    public static IEnumerable<TResult> GetNonNonVerifiedPersons<TResult>(Person<TResult> model)
    {
        var list = model.PersonList;
        var t = list.FirstOrDefault() as Teacher;
        if (t != null)
        {
            return model.PersonList.Where(x => !(x as Teacher).IsVerified);
        }
        var s = list.FirstOrDefault() as Student;
        if (s != null)
        {
            return model.PersonList.Where(x => !(s as Student).IsVerified);
        }
        return null;
    }
