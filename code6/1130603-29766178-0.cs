    public static T GetNext<SomeEntity>(
                this IOrderedQueryable<SomeEntity> list,
                SomeEntity current)
    {
        return list.Where(elem => elem.Id > current.Id)
                   .FirstOrDefault(); // faster than try-catch
         // assuming, that Id is unique
    }
