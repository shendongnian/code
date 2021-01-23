    public TDTO GetEntityById<TDTO>(object id)
        where TDTO : class
    {
        using (var context = new MyDbContext())
        {
            var entity = context.Set(DTOResolver<TDTO>.SetType).Find(id);
            if (entity == null)
                return default(TDTO);
            return DTOResolver<TDTO>.SetMapper.Map(entity);
        }
    }
